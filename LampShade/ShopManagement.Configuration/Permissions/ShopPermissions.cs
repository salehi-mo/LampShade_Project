using System.ComponentModel;

namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Product
        public const int ListProducts = 10000;
        public const int SearchProducts = 10001;
        public const int CreateProduct = 10002;
        public const int EditProduct = 10003;


        //ProductCategory
        public const int ListProductCategories = 10100;
        public const int SearchProductCategories = 10101;
        public const int CreateProductCategory = 10102;
        public const int EditProductCategory = 10103;

        //ProductPicture
        public const int ListProductPictures = 10200;
        public const int SearchProductPictures = 10201;
        public const int CreateProductPicture = 10202;
        public const int EditProductPicture = 10203;
        public const int RemoveProductPicture = 10204;

        //Slider
        public const int ListSliders = 10300;
        public const int SearchSliders = 10301;
        public const int CreateSlider = 10302;
        public const int EditSlider = 10303;
        public const int RemoveSlider = 10304;
    }
}