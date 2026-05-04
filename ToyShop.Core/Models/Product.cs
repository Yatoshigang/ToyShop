using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Models
{
    public class Product
    {
        public int Id_prod { get; set; }
        public string Name_prod { get; set; }
        public string Article { get; set; }
        public int Barcode { get; set; }
        public decimal Price { get; set; }
        public int Quantity_sklad { get; set; }
        public int AgeRestriction { get; set; }

        public Brand Brand { get; set; } = new();
        public int Id_brand { get => Brand.Id_br; }
        public Category Category { get; set; } = new();
        public int Id_category { get => Category.Id_cat; }
        public Supplier Supplier { get; set; } = new();
        public int Id_suppl { get => Supplier.Id_sup; }

        public Product(string name, string article, int barcode, decimal price, int quantity, int ageRestriction)
        {
            Name_prod = name;
            Article = article;
            Barcode = barcode;
            Price = price;
            Quantity_sklad = quantity;
            AgeRestriction = ageRestriction;

            Brand = new();
            Category = new();
            Supplier = new();
        }

        public Product() : this(string.Empty, string.Empty, -1, -1, 0, 0) { }

    }
}
