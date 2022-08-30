using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailStoreApplication.Models;

namespace RetailStoreApplication.Context
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
