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
        public Status Status { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Product? Product { get; set; } 
        public int ProductId { get; set; }
        public User? User { get; set; } 
        public int UserId { get; set; }

        public Sale(DateTime date_sale, Status status, int quantity, int totalAmount)
        {
            Date_sale = date_sale;
            Status = status;
            Quantity = quantity;
            TotalAmount = totalAmount;

        }

        public Sale() : this(DateTime.Now, Status.Pending, 0, 0)
        {
            
        }
    }

   
}
