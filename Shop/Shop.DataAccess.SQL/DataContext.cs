﻿using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        //CONSTRUCTOR
        public DataContext() :base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
