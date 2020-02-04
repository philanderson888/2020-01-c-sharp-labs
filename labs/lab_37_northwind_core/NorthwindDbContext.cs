﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace lab_37_northwind_core
{

    // talk to database by using Entity Libraries ( : DbContext)
    public class NorthwindDbContext : DbContext
    {
        // connection string
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind;");
        }


        // DbSet customer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
