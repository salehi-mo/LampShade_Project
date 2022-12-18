using System.ComponentModel;

namespace DiscountManagement.Configuration.Permissions
{
    public static class DiscountPermissions
    {
        //CustomerDiscounts
        public const int ListCustomerDiscounts = 10500;
        public const int SearchCustomerDiscounts = 10501;
        public const int CreateCustomerDiscount = 10502;
        public const int EditCustomerDiscount = 10503;


        //ColleagueDiscounts
        public const int ListColleagueDiscounts = 10600;
        public const int SearchColleagueDiscounts = 10601;
        public const int CreateColleagueDiscount = 10602;
        public const int EditColleagueDiscount = 10603;
        public const int RemoveColleagueDiscount = 10604; 
        


    }
}