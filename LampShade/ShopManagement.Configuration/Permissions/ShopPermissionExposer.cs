using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                   new List<string>()
                   {
                       "Product",
                       "محصولات"
                   },
                   new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProducts, "ListProducts","لیست محصولات"),
                        new PermissionDto(ShopPermissions.SearchProducts, "SearchProducts","جستجوی محصولات"),
                        new PermissionDto(ShopPermissions.CreateProduct, "CreateProduct","ایجاد محصول جدید"),
                        new PermissionDto(ShopPermissions.EditProduct, "EditProduct","ویرایش محصول"),
                    }
                },
                {
                    new List<string>()
                    {
                        "ProductCategory",
                        "گروه محصولات"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchProductCategories, "SearchProductCategories","جستجوی گروه محصولات"),
                        new PermissionDto(ShopPermissions.ListProductCategories, "ListProductCategories","لیست گروه محصولات"),
                        new PermissionDto(ShopPermissions.CreateProductCategory, "CreateProductCategory","ایجاد گروه محصول جدید"),
                        new PermissionDto(ShopPermissions.EditProductCategory, "EditProductCategory","ویرایش گروه محصول"),
                    }
                },
                {
                    new List<string>()
                    {
                        "ProductPicture",
                        "عکس محصولات"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchProductPictures, "SearchProductPictures","جستجوی عکس محصولات"),
                        new PermissionDto(ShopPermissions.ListProductPictures, "ListProductPictures","لیست عکس محصولات"),
                        new PermissionDto(ShopPermissions.CreateProductPicture, "CreateProductPicture","ایجاد عکس محصول جدید"),
                        new PermissionDto(ShopPermissions.EditProductPicture, "EditProductPicture","ویرایش عکس محصول"),
                        new PermissionDto(ShopPermissions.RemoveProductPicture, "RemoveProductPicture","حذف/فعالسازی عکس محصول"),
                    }
                },
                {
                    new List<string>()
                    {
                        "Slider",
                        "اسلایدر"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchSliders, "SearchSliders","جستجوی اسلایدر"),
                        new PermissionDto(ShopPermissions.ListSliders, "ListSliders","لیست اسلایدر"),
                        new PermissionDto(ShopPermissions.CreateSlider, "CreateSlider","ایجاد اسلایدر جدید"),
                        new PermissionDto(ShopPermissions.EditSlider, "EditSlider","ویرایش اسلایدر"),
                        new PermissionDto(ShopPermissions.RemoveSlider, "RemoveSlider","حذف/فعالسازی اسلایدر"),
                    }
                }
            };
        }
    }
}