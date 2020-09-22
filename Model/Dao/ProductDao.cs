using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
     public class ProductDao
    {
        ProjectShopDbContext db = new ProjectShopDbContext();
        public ProductDao()
        {
            db = new ProjectShopDbContext();
        }

        public List<Product> ListProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

         //Get list product
        //public List<Product> ListByCategoryId(long categoryID)
        //{
        //    return db.Products.Where(x => x.CategoryID == categoryID).ToList()  ;
        //}
       public Product ViewDetailProduct(long id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListProductOther(long productID) // danh sách khác sản phẩm đang xem
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID).ToList();
        }
        public List<Product> ListALL()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public List<Product> AllProduct(ref int totalRecord, int pageIndex = 1, int pageSize = 2)// Phân trang bài 36 17p
        {
            totalRecord = db.Products.Where(x => x.Status == true).Count();
            var model = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        //public List<Product> AllProduct()// Phân trang bài 36 17p
        //{

        //    return db.Products.Where(x => x.Status == true).ToList();

        //}
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreateDate,
                             ID = a.ID,
                             Images = a.Images,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<Product> ListSearch(string search)
        {
            return db.Products.Where(x => x.Name == search).ToList();
        }

    }
}
