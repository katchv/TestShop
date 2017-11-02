using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();
        public static int size = 6;

        public Page MakePage(int num)
        {
            return new Page { number = num, size = size, allItems = db.products.Count(), prods = db.products.OrderBy(x => x.Id).Skip((num - 1) * size).Take(size) };
        }

        public ActionResult Index(int num =1)
        {
            ViewBag.Page = MakePage(num);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ToCart(int num,int id)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand("setToCart @id", param);
            ViewBag.Page = MakePage(num);
            return View();
        }

    }
}
