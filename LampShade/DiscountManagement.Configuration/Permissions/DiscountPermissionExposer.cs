using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace DiscountManagement.Configuration.Permissions
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                    new List<string>()
                   {
                       "CustomerDiscount",
                       "تخفیف مشتری"
                   },
                   new List<PermissionDto>
                    {
                        new PermissionDto(DiscountPermissions.ListCustomerDiscounts ,  "ListCustomerDiscounts","لیست تخفیف مشتری"),
                        new PermissionDto(DiscountPermissions.SearchCustomerDiscounts, "SearchCustomerDiscounts","جستجوی تخفیف مشتری"),
                        new PermissionDto(DiscountPermissions.CreateCustomerDiscount, "CreateCustomerDiscount","ایجاد تخفیف مشتری جدید"),
                        new PermissionDto(DiscountPermissions.EditCustomerDiscount, "EditCustomerDiscount","ویرایش تخفیف مشتری"),
                    }
                },
                {
                    new List<string>()
                    {
                        "ColleagueDiscount",
                        "تخفیف همکار"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(DiscountPermissions.ListColleagueDiscounts, "ListColleagueDiscounts","جستجوی تخفیف همکار"),
                        new PermissionDto(DiscountPermissions.SearchColleagueDiscounts, "SearchColleagueDiscounts","لیست تخفیف همکار"),
                        new PermissionDto(DiscountPermissions.CreateColleagueDiscount, "CreateColleagueDiscount","ایجاد تخفیف همکار جدید"),
                        new PermissionDto(DiscountPermissions.EditColleagueDiscount, "EditColleagueDiscount","ویرایش تخفیف همکار"),
                        new PermissionDto(DiscountPermissions.RemoveColleagueDiscount, "RemoveColleagueDiscount","حذف/فعالسازی تخفیف همکار"),
                    }
                }
            };
        }
    }
}