using Common;
using Model.Dao;
using Model.EF;
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectMVC.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetailProduct(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối  tượng
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;

            }
            else
            {
                //tạo mới đối  tượng
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;

            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;

            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession]; // danh sach gio hang
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            }); // đối tượng trả về
        }
        public JsonResult Update( string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>) Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
                    
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {

                status = true
            });
            //Kiểm tra lỗi 26:00 bài 40
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(CartItem model)
        {
            
            // lấy từng thuộc tính trong SQL
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = model.address;
            order.ShipMobile = model.mobile;
            order.ShipEmail = model.email;
            order.ShipName = model.shipName;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/Template/information.html"));

                content = content.Replace("{{CustomerName}}", model.shipName);
                content = content.Replace("{{Phone}}", model.mobile);
                content = content.Replace("{{Email}}", model.email);
                content = content.Replace("{{Address}}", model.address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new Class1().SendMail(model.email, "Đơn hàng mới từ OnlineShop", content);
                new Class1().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch ( Exception ex)
            {
                //var loi = ex.ToString();
                //return Redirect("/loi-thanh-toan"+ex);
             
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Validate (CartItem model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bạn đã gửi được thông tin!");
                
            }
            return View("Payment");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}