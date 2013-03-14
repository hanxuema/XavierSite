using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XavierSite.Areas.OnlineStore.Concrete;
using XavierSite.DB;

namespace XavierSite.Areas.OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private XavierSiteConnect db = new XavierSiteConnect();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddtoCart(int id)
        {
            Product product = new Product();
            product = db.Products.Find(id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            ViewData["newProduct"] = product;
            Session["newProduct"] = product;
            return RedirectToAction("CartDetail");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int productId)
        {
            Product product = db.Products.Find(productId);
            if (product!= null)
            {
                GetCart().RemoveItem(product);
            }
            return RedirectToAction("CartDetail");
        }

        public ActionResult ConfirmItemInCart()
        {
            ViewBag.confirmPro = ((Product)Session["newProduct"]).Name;
            return View();
        }

        public  ActionResult CartDetail()
        {
            return View(GetCart());
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }
            return cart;
        }


    }
}
