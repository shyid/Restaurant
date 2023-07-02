using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RST_WebApi.Models;

namespace RST_WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Appetize> Appetizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Food>().HasData(
                new Food
                {
                Id = 1,
                Name = "Pepperoni pizza",
                Details = "It has pepperoni and pizza cheese",
                ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                Rate = 150,
                FoodStatus = 0,
                CreatedDate = DateTime.Now
                },
              new Food
              {
                Id = 2,
                Name = "Meat pizza",
                Details = "It has meat, mushroom and pizza cheese",
                ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                Rate = 150,
                FoodStatus = 0,
                CreatedDate = DateTime.Now
              },
              new Food
              {
                Id = 3,
                Name = "Chicken pizza",
                Details = "It has chicken, mushroom and cheese pizza",
                ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                Rate = 150,
                FoodStatus = 0,
                CreatedDate = DateTime.Now
              }
              
            );
        }
    }
}