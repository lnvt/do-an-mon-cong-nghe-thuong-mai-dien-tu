using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index( string searchString , int page = 1, int pageSize = 2)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString ,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm admin thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var  result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật admin thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete (int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}