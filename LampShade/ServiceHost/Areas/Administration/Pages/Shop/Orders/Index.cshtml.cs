using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ServiceHost.Areas.Administration.Pages.Accounts.Role;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }

        public OrderSearchModel SearchModel;
        public SelectList Accounts;
        public List<OrderViewModel> Orders;
        public List<OrderItemViewModel> OrderItems;
        public List<OrderItemViewModel> OrderItemsIsNotStock=new List<OrderItemViewModel>();


        private readonly IOrderApplication _orderApplication;
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountApplication _accountApplication;
        private readonly IProductQuery _productQuery;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication, IProductQuery productQuery, IOrderRepository orderRepository)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
            _productQuery = productQuery;
            _orderRepository = orderRepository;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            if (TempData["list_OrderItemsIsNotStock"] != null)
                OrderItemsIsNotStock = JsonConvert.DeserializeObject<List<OrderItemViewModel>>(TempData["list_OrderItemsIsNotStock"].ToString());
           
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
            Orders = _orderApplication.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long id)
        {


            OrderItems = _orderApplication.GetItems(id);
            var cartItems = new List<CartItem>();
            foreach (var item in OrderItems)
            {
                var cartItem = new CartItem(item.ProductId, item.UnitPrice, item.Count, item.DiscountRate,
                    item.Product);
                cartItem = _productQuery.CheckInventoryStatusForOne(cartItem);
                if (!cartItem.IsInStock)
                {
                    cartItems.Add(cartItem);
                    OrderItemsIsNotStock.Add(item);
                }
            }
            if (cartItems.Count > 0)
            {
                ErrorMessage = ApplicationMessages.ProductIsNotInStock;
                TempData["list_OrderItemsIsNotStock"] = JsonConvert.SerializeObject(OrderItemsIsNotStock.ToList()) ;
                
                return RedirectToPage("./Index");
                //return Partial("ItemsNotInInventory", OrderItemsIsNotStock);
            }
            else
            {
                _orderApplication.PaymentSucceeded(id, 0);
                return RedirectToPage("./Index");
            }


            //OrderItems = _orderApplication.GetItems(id);
            //var cartItems = new List<CartItem>();
            //foreach (var item in OrderItems)
            //{
            //    var cartItem = new CartItem(item.ProductId, item.UnitPrice, item.Count, item.DiscountRate,item.Product);
            //    cartItem = _productQuery.CheckInventoryStatusForOne(cartItem);
            //    if (!cartItem.IsInStock)
            //    {
            //        cartItems.Add(cartItem);
            //        OrderItemsIsNotStock.Add(item);
            //    }
            //}
            //if (cartItems.Count > 0)
            //{

            //    return Partial("ItemsNotInInventory", OrderItemsIsNotStock);
            //}
            //else
            //{
            //    _orderApplication.PaymentSucceeded(id, 0);
            //    return RedirectToPage("./Index");
            //}



        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetItems(id);
            return Partial("Items", items);
        }
        public IActionResult OnGetItemsNotInInventory(long id)
        {

            OrderItems = _orderApplication.GetItems(id);
            var cartItems = new List<CartItem>();
            foreach (var item in OrderItems)
            {
                var cartItem = new CartItem(item.ProductId, item.UnitPrice, item.Count, item.DiscountRate, item.Product);
                cartItem = _productQuery.CheckInventoryStatusForOne(cartItem);
                if (!cartItem.IsInStock)
                    cartItems.Add(cartItem);
                OrderItemsIsNotStock.Add(item);
            }
            if (cartItems.Count > 0)
            {
                return Partial("ItemsNotInInventory", OrderItemsIsNotStock);
            }
            else
            {
                _orderApplication.PaymentSucceeded(id, 0);
                return RedirectToPage("./Index");
            }

            //var items = _orderApplication.GetItems(id);
            //return Partial("Items", items);
        }


    }
}