using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class CartItemFull
    {
        public int CartItemId { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
    }
}