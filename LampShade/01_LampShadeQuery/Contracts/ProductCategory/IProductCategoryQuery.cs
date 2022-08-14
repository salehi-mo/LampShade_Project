using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProdcutCategoryQueryModel> GetProductCategories();
    }
}
