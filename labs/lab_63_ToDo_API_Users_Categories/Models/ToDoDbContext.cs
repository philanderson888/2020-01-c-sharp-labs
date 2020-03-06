using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab_63_ToDo_API_Users_Categories.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) 
            :base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        string connectionString = "Data Source = (localdb)\\mssqllocaldb;" +
            "Initial Catalog = ToDoDatabase2";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        // add FluentAPI and Seeding
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // relationships

            builder.Entity<User>()
                .HasMany(user => user.ToDos)
                .WithOne(user => user.User);
            builder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            // seeding
            builder.Entity<User>().HasData(
                
                new User { UserId = 1, UserName = "Fred" },
                new User { UserId = 2, UserName = "Bob" },
                new User { UserId = 3, UserName = "Pete" },
                new User { UserId = 4, UserName = "Tim" },
                new User { UserId = 5, UserName = "Serena" }
                );
            builder.Entity<ToDo>().HasData(
                new ToDo { ToDoId = 1, ToDoName = "Do This" },
                new ToDo { ToDoId = 2, ToDoName = "And Do This" },
                new ToDo { ToDoId = 3, ToDoName = "And Do This Also" }
                );
        }


    }
}
