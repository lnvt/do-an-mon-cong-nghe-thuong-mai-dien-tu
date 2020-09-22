using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //Slide chiếu trong bài 32: 10m
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new MenuDao().ListByGroupId(3);
            return PartialView(model);
        }

        //bigint sang MVC là long
        public ActionResult Category(long id)
        {
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            return View(category);
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetailProduct(id);
            ViewBag.Category = new ProductDao().ViewDetailProduct(id);
            ViewBag.ProductOther = new ProductDao().ListProductOther(id);
            return View(product);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }



    }
}