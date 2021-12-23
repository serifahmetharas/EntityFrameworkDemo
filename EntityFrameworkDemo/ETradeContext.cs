using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    // Veritabanının Context classıdır.
    class ETradeContext :DbContext
    {
        public DbSet<Product> Products { get; set; } // ETrade veritabanındaki tablolarda Products arıyor.
    }
}
