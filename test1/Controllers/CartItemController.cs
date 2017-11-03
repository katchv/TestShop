using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class CartItemController : Controller
    {
        ShopContext db = new ShopContext();
        public static int size = 6;
        public static NumberFormatInfo us_nfi = new CultureInfo("en-US").NumberFormat;

        public string Bill()
        {
            var items = db.Database.SqlQuery<CartItemFull>("getFullCart");
            decimal sum = 0;
            foreach (var i in items)
                sum += i.Price * i.Quantity;
            return string.Format(us_nfi, "{0:F2}", sum);
        }
        public PageCart MakePage(int num)
        {
            var items = db.Database.SqlQuery<CartItemFull>("getFullCart");
            return new PageCart { number = num, size = size, allItems = items.Count(), cartitems = items.OrderBy(x => x.CartItemId).Skip((num - 1) * size).Take(size),bill=Bill() };
        }

        public ActionResult Index(int num = 1)
        {
           ViewBag.PageCart = MakePage(num);
            return View(ViewBag.PageCart);
        }

        [HttpPost]
        public ActionResult DelItem(int num,int id )
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand("delFromCart @id", param);

            return RedirectToAction("Index", "CartItem", new { num = num });
        }

        [HttpPost]
        public ActionResult ChangeQuantity(int num,int id,int flag)
        {
            System.Data.SqlClient.SqlParameter paramid = new System.Data.SqlClient.SqlParameter("@id", id);
            System.Data.SqlClient.SqlParameter paramflag = new System.Data.SqlClient.SqlParameter("@flag", flag);
            db.Database.ExecuteSqlCommand("changeQu @id, @flag", paramid,paramflag);

            return RedirectToAction("Index", "CartItem", new { num = num });
        }

        public ActionResult Pay()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Fail()
        {
            return View();
        }

    }
}