using System;
using System.Collections.Generic;
using System.Text;
using ToyShop.Core.Representations;

namespace ToyShop.Core.Models
{
    /// <summary>
    /// Класс-модель продаж
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date_sale { get; set; }
        public Statuses Status { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; } = new();
        public int Id_cust { get => Customer.Id; }
        public Product Product { get; set; } = new();
        public int Id_prod { get => Product.Id; }
        public User User { get; set; } = new();
        public int Id_user { get => User.Id; }

        public Sale(DateTime date_sale, Statuses status, int quantity, int totalAmount)
        {
            Date_sale = date_sale;
            Status = status;
            Quantity = quantity;
            TotalAmount = totalAmount;

            Customer = new();
            Product = new();
            User = new();
        }

        public Sale() : this(DateTime.Now, Statuses.Pending, 0, 0)
        {
            
        }
    }

   
}
