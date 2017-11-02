using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class PageCart
    {
        public int number { get; set; }
        public int size { get; set; }
        public int allItems { get; set; }

        public IEnumerable<CartItemFull> cartitems { get; set; }

        public string bill { get; set; }
        public int allPages
        {
            get { return (int)Math.Ceiling((decimal)allItems / size); }
        }
    }
}