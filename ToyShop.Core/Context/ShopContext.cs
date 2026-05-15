using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToyShop.Core.Models;

namespace ToyShop.Core.Context
{
    public class ShopContext : DbContext
    {

        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopContext()
        {
            if (Database.EnsureCreated())
            {

                if (Users == null || !Users.Any())
                {
                    Users.AddRange(new User("Spenser", "Tom", "Lil", "Tom@gmail.com", "LilTom", "qwerty"), new User("Lake", "Anna", "Villa", "Anna@gmail.com", "Admin", "qwerty"));
                    SaveChanges();
                }
                if (Suppliers == null || !Suppliers.Any())
                {
                    Suppliers.Add(new Supplier("ООО \"Марка\"", "Россия", "89803934959"));
                    SaveChanges();
                }
                if (Administrations == null || !Administrations.Any())
                {
                    Administrations.Add(new Administration("Lake", "Anna", "Villa", "Anna@gmail.com", "Admin", "qwerty"));
                    SaveChanges();
                }
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToyShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));
        }
    }
}
