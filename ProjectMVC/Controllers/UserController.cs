using Model.Dao;
using Model.EF;
using ProjectMVC.Areas.Admin.Models;
using ProjectMVC.Common;
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {

            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!");
                }
                else
                {

                    var user = new User();
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.CreateDate = DateTime.Now;
                    user.Status = true;
                    user.UserName = model.UserName;
                    user.Password = model.ConfirmPassword;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        model = new Register();
                        ModelState.AddModelError("", "Bạn đã đăng kí thành công!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công.");
                    }
                }



            }
            return View("Register");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Areas.Admin.Models.LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new Common.UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
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
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}