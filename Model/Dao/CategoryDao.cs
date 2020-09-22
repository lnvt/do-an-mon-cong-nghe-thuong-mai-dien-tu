using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        ProjectShopDbContext db = null;
        public CategoryDao()
        {
            db = new ProjectShopDbContext();
        }

        public ProductCategory ViewDetail( long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
