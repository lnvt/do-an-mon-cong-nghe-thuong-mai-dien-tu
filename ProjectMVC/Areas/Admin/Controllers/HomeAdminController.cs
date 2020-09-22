using Model.Dao;
using ProjectMVC.Areas.Admin.Models;
using ProjectMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult HeaderAdmin()
        {
            return PartialView();
        }
    }
}