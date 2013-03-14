using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XavierSite.DB;

namespace XavierSite.Areas.OnlineStore.Concrete
{
    public class Cart
    {

        private List<CartList> cartListCollection = new List<CartList>();

        public void AddItem(Product product, int quantity)
        {
            var currentCart = (from c in cartListCollection
                               where c.Product.ProductId == product.ProductId
                               select c).FirstOrDefault();
            
            if (currentCart != null)
            {
                currentCart.Quantity = currentCart.Quantity + quantity;
            }
            else
            {
                cartListCollection.Add(new CartList { Product = product, Quantity = quantity});
            }
        }

        public void RemoveItem(Product product)
        {
            cartListCollection.RemoveAll(c => c.Product.ProductId == product.ProductId);
        }

        public void Clear()
        {
            cartListCollection.Clear();
        }

        public decimal TotalValue()
        {
            return cartListCollection.Sum(c => c.Product.Price * c.Quantity);
        }

        public List<CartList> Lines
        {
            get { return cartListCollection; }
        }
    }
}