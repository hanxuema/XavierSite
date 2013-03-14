using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XavierSite.DB;

namespace XavierSite.Areas.OnlineStore.Concrete
{
    public class CartList
    {
        private int quantity;
        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
        
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
    }
}
