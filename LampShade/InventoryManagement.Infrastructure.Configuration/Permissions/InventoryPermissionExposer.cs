using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManagement.Infrastructure.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                    new List<string>()
                    {
                        "Inventory",
                        "انبار"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(InventoryPermissions.ListInventory, "ListInventory","لیست انبار"),
                        new PermissionDto(InventoryPermissions.SearchInventory, "SearchInventory","جستجوی انبار"),
                        new PermissionDto(InventoryPermissions.CreateInventory, "CreateInventory","ایجاد انبار جدید"),
                        new PermissionDto(InventoryPermissions.EditInventory, "EditInventory","ویرایش انبار"),
                        new PermissionDto(InventoryPermissions.Increase, "Increase","افزایش موجودی"),
                        new PermissionDto(InventoryPermissions.Reduce, "Reduce","کاهش موجودی"),
                        new PermissionDto(InventoryPermissions.OperationLog, "OperationLog","مشاهده گردش انبار")
                    }
                }
            };
        }

    }
}