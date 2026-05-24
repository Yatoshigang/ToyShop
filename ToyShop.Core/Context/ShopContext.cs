using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ToyShop.Core.Models;
using ToyShop.Core.Representations;

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
            User user = new User { Id = 1, LastName = "Spenser", FirstName = "Tom", MiddleName = "Lil", Email = "Tom@gmail.com", Login = "LilTom", Password = "qwerty" };
            Administration admin = new Administration { Id = 1, LastName = "Spenser", FirstName = "Richard", MiddleName = "Swen", Email = "Dick@gmail.com", Login = "Admin", Password = "qwerty" };

            Brand lego = new Brand { Id = 1, Name = "lego", Country = "USA", DateOfOpen = new DateOnly(2000, 5, 12), Site = "lego.com" };
            Brand hasbro = new Brand { Id = 2, Name = "Hasbro", Country = "USA", DateOfOpen = new DateOnly(2000, 5, 12), Site = "Hasbro.com" };

            Category construct = new Category { Id = 1, Name_cat = "Конструкторы" };
            Category board = new Category { Id = 2, Name_cat = "Настольные игры" };

            Supplier sup = new Supplier { Id = 1, Name_sup = "ООО \"Марка\"", Country_sup = "Россия", Number = "89803934959" };

            Customer customer = new Customer { Id = 1, LastName = "Винирова", FirstName = "Анна", MiddleName = "Сергеевна", Email = "vinir@mail.ru", Number = "89832343234", DateOfBirth = new DateOnly(1996, 5, 12) };

            Product[] products = {new Product { Id = 1, Name_prod = "Монополия", Article = "Monopslia", Barcode = 190, Price = 2000, Quantity_sklad = 40, AgeRestriction = 0, CategoryId = board.Id, BrandId = hasbro.Id, SupplierId = sup.Id},
                          new Product { Id = 2, Name_prod = "UNO", Article = "Uno", Barcode = 200, Price = 1300, Quantity_sklad = 100, AgeRestriction = 6, CategoryId = board.Id, BrandId = hasbro.Id, SupplierId = sup.Id },
                          new Product { Id = 3, Name_prod = "Lego Duplo", Article = "Duplo", Barcode = 13, Price = 3500, Quantity_sklad = 200, AgeRestriction = 3, CategoryId = construct.Id, BrandId = lego.Id,SupplierId = sup.Id},
                          new Product { Id = 4, Name_prod = "Lego Technic", Article = "Techno", Barcode = 16, Price = 6000, Quantity_sklad = 150, AgeRestriction = 14, CategoryId = construct.Id, BrandId = lego.Id, SupplierId = sup.Id}};
            modelBuilder.Entity<User>(b =>
            {
                b.HasData(user);
            });


            modelBuilder.Entity<Administration>(b =>
            {
                b.HasData(admin);
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.HasData(lego, hasbro);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasData(construct, board);
            });

            modelBuilder.Entity<Supplier>(b =>
            {
                b.HasData(sup);
            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasData(customer);
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.HasData(products);
            });

            modelBuilder.Entity<Sale>(b =>
            {
                b.HasData(new Sale { Id = 1, Date_sale = new DateTime(2026, 10, 12, 22, 30, 0,0), Status = Status.PaymentAwait, Quantity = 2, TotalAmount = 4000, UserId = user.Id, CustomerId = customer.Id, ProductId = products[0].Id },
                          new Sale { Id = 2, Date_sale = new DateTime(2026, 10, 12, 22, 30, 0, 0), Status = Status.Paid, Quantity = 3, TotalAmount = 3900, UserId = user.Id, CustomerId = customer.Id, ProductId = products[1].Id },
                          new Sale { Id = 3, Date_sale = new DateTime(2026, 10, 12, 22, 30, 0, 0), Status = Status.Completed, Quantity = 1, TotalAmount = 3500, UserId = user.Id, CustomerId = customer.Id, ProductId = products[2].Id },
                          new Sale { Id = 4, Date_sale = new DateTime(2026, 10, 12, 22, 30, 0, 0), Status = Status.Adopted, Quantity = 10, TotalAmount = 60000, UserId = user.Id, CustomerId = customer.Id, ProductId = products[3].Id });
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToyShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));
        }
    }
}
