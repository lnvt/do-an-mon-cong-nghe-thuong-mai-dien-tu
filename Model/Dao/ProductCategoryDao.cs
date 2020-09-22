using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        ProjectShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ProjectShopDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

      
    }
}
