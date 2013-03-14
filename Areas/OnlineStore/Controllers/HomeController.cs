using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XavierSite.DB;

namespace XavierSite.Areas.OnlineStore.Views.Home
{
    public class HomeController : Controller
    {
        //
        // GET: /OnlineStore/Home/
        private XavierSiteConnect db = new XavierSiteConnect();

        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            products = db.Products.ToList();

            return View(products);
        }

    }
}
