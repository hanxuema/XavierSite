using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XavierSite.DB;

namespace XavierSite.Areas.OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /OnlineStore/Product/

        private XavierSiteConnect db = new XavierSiteConnect();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductInCart(int id)
        {
            HttpCookie cookie = new HttpCookie("cart");
       

            return View();
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = db.Products.Find(productId);

            if (productId != null)
            {
                return File(product.Picture, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
    }
}
