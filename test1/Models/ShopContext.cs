using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class ShopContext: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<CartItem> cartitems { get; set; }
    }
}