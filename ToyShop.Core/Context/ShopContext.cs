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
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User { Id = 1, LastName = "Spenser", FirstName = "Tom", MiddleName = "Lil", Email = "Tom@gmail.com", Login = "LilTom", Password="qwerty"});
            });

            
            modelBuilder.Entity<Administration>(b =>
            {
                b.HasData(new Administration { Id = 1, LastName = "Spenser", FirstName = "Richard", MiddleName = "Swen", Email = "Dick@gmail.com", Login = "Admin", Password = "qwerty" });
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.HasData(new Brand { Id = 1, Name = "lego", Country = "USA", DateOfOpen = new DateOnly(2000, 5, 12), Site = "lego.com" });
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasData(new Category { Id = 1, Name_cat = "Конструкторы" }, new Category { Id = 2, Name_cat = "Настольные игры" });
            });

            modelBuilder.Entity<Supplier>(b =>
            {
                b.HasData(new Supplier { Id = 1, Name_sup = "ООО \"Марка\"", Country_sup = "Россия", Number = "89803934959" });
            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasData(new Customer { Id = 1, LastName = "Винирова", FirstName = "Анна", MiddleName = "Сергеевна", Email = "vinir@mail.ru", Number = "89832343234", DateOfBirth = new DateOnly(1996, 5, 12) });
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.HasData();
            });

            modelBuilder.Entity<Sale>(b =>
            {
                b.HasData();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));
        }
    }
}
