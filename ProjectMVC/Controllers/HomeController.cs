using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using ProjectMVC.Models;
using ProjectMVC.Common;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
      
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.Newproduct = productDao.ListProduct(4);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenuTop()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }


        [ChildActionOnly]
        public ActionResult MenuFooter2()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
        
            return PartialView(list);
        }

        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SeeAllProduct(int? page =1/*int page=1, int pageSize =5*/ )
        {
            //int totalRecord = 0;
            //var model = new ProductDao().ListALL(ref totalRecord, page, pageSize);
            //ViewBag.allproduct = model;
            //ViewBag.Total = totalRecord;
            //ViewBag.Page = page;

            //int maxPage = 10;
            //int totalPage = 0;
            //totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            //ViewBag.Totalpage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = totalPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            var MoDel = new ProductDao().ListALL().OrderByDescending(x => x.ID).ToPagedList(page ?? 1,4);
            ViewBag.phantrang = MoDel;
            return View( MoDel);
        }
    }
}