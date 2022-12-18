namespace ShopManagement.Application.Contracts.Order
{
    public class CartItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Picture { get; set; }
        public int Count { get; set; }
        public double TotalItemPrice { get; set; }
        public bool IsInStock { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double ItemPayAmount { get; set; }

        public CartItem(long id, double unitPrice, int count,  double discountAmount,string product)
        {
            Id = id;
            UnitPrice = unitPrice;
            Count = count;
            DiscountAmount = discountAmount;
            Name = product;
        }

        public CartItem()
        {
            TotalItemPrice = UnitPrice * Count;
        }

        public void CalculateTotalItemPrice()
        {
            TotalItemPrice = UnitPrice * Count;
        }
    }
}