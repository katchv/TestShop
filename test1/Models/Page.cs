using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class Page
    {
        public int number { get; set; }
        public int size { get; set; }
        public int allItems { get; set; }

        public IEnumerable<Product> prods { get; set; }

        public int allPages
        {
            get { return (int) Math.Ceiling((decimal) allItems/size); }
        }


    }
}