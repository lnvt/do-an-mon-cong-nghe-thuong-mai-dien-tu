using Model.Dao;
using ProjectMVC.Areas.Admin.Models;
using ProjectMVC.Common;
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginModel = ProjectMVC.Areas.Admin.Models.LoginModel;

namespace ProjectMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.Password = user.Password;
                    userSession.Email = user.Email;
                    userSession.Address = user.Address;
                    userSession.Phone = user.Phone;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View("Index");
        }

    }
}