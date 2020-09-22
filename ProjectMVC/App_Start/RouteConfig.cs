using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
       name: "Search",
       url: "tim-kiem",
       defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }

   );
            routes.MapRoute(
         name: "Xemthongtin",
         url: "xem-thong-tin-sinh-vien",
         defaults: new { controller = "Sinhvien", action = "Index", id = UrlParameter.Optional }

         );
            routes.MapRoute(
         name: "Login",
         url: "dang-nhap-KH",
         defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }

         );
            routes.MapRoute(
          name: "Register",
          url: "dang-ki",
          defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }

          );

            routes.MapRoute(
            name: "Success",
            url: "hoan-thanh",
            defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }

            );
            routes.MapRoute(
         name: "Payment",
         url: "thanh-toan",
         defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }

          );
            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }

        );
            routes.MapRoute(
            name: "Add Cart",
            url: "them-gio-hang",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }

        );
            routes.MapRoute(
            name: "Xem tat ca",
            url: "xem-tat-ca",
            defaults: new { controller = "Home", action = "SeeAllProduct", id = UrlParameter.Optional }

        );
            routes.MapRoute(
              name: "Chi tiet",
              url: "chi-tiet/{metatile}-{id}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }

          );
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }

           );
            routes.MapRoute(
               name: "News",
               url: "tin-tuc",
               defaults: new { controller = "Home", action = "News", id = UrlParameter.Optional }

           );
            routes.MapRoute(
                name: "Introduce",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "Introduce", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Milk Tea",
                url: "milktea/{metatile}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Milk Tea Detail",
                url: "chi-tiet/{metatile}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }

            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectShop.Controller" }
            );
        }

    }
}
