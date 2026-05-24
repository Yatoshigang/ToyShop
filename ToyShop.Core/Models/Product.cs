using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Models
{
    /// <summary>
    /// Класс-модель продукции
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name_prod { get; set; }
        public string Article { get; set; }
        public int Barcode { get; set; }
        public decimal Price { get; set; }
        public int Quantity_sklad { get; set; }
        public int AgeRestriction { get; set; }

        public Brand? Brand { get; set; }
        public int BrandId { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Supplier? Supplier { get; set; }
        public int SupplierId { get; set; }

        public Product(string name, string article, int barcode, decimal price, int quantity, int ageRestriction)
        {
            Name_prod = name;
            Article = article;
            Barcode = barcode;
            Price = price;
            Quantity_sklad = quantity;
            AgeRestriction = ageRestriction;

        }

        public Product() : this(string.Empty, string.Empty, -1, -1, 0, 0) { }

    }
}
