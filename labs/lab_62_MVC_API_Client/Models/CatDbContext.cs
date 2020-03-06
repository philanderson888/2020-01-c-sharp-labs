using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace lab_62_MVC_API_Client.Models
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options)
            : base(options) { }


        // DbSet = SQL Table Names
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Category> Categories { get; set; }

        string connectionString = "Data Source = (localdb)\\mssqllocaldb;" +
            "Initial Catalog = CatDatabase";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                
                new Category { CategoryId = 1, CategoryName = "Bengal" },
                new Category { CategoryId = 2, CategoryName = "Tabby" },
                new Category { CategoryId = 3, CategoryName = "Siamese" }
                );

            builder.Entity<Cat>().HasData(
                new Cat { CatId = 1, CatName = "Sanjana" , CategoryId = 1 },
                new Cat { CatId = 2, CatName = "Petrova" , CategoryId = 3  },
                new Cat { CatId = 3, CatName = "George" , CategoryId = 2  }
                );



            // add fluent relationships
            builder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Entity<Cat>()
                .HasOne(c => c.Category);

        }




    }
}
