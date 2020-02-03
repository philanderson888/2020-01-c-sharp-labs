using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace lab_37_northwind_core
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static string CustomersPath = "customers.csv";

        static void Main(string[] args)
        {
            using (var db = new NorthwindDbContext()) {
                customers = db.Customers.ToList();
            }
            PrintCustomers();
            Process.Start("EXCEL", CustomersPath);
        }

        static void PrintCustomers()
        {
            if (File.Exists("customers.csv")) File.Delete("customers.csv");       // start afresh
            File.AppendAllText("customers.csv", "ID,Name,Company,City,Country"
                 + Environment.NewLine);  // header
            // print 5 fields  ID ContactName CompanyName City Country
            customers.ForEach(c =>
            {
                string customerData = $"{c.CustomerID},{c.ContactName},{c.CompanyName}," +
                        $"{c.City},{c.Country}\n";
                Console.WriteLine(customerData);
                // output to csv 5 fields
                File.AppendAllText("customers.csv", customerData);
            });
        }
    }

    // talk to database by using Entity Libraries ( : DbContext)
    class NorthwindDbContext : DbContext
    {
        // connection string
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind;");
        }


        // DbSet customer
        public DbSet<Customer> Customers { get; set; }
    }

    public partial class Customer
    {
        

        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }


    }

    class Product
    {

    }

    class Supplier
    {

    }
}
