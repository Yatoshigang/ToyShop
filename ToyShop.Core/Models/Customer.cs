using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Models
{
    public class Customer
    {
        public int Id_cust {  get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email {  get; set; }
        public string Number { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfRegistration { get; set; }

        public Customer()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            Email = string.Empty;
            Number = string.Empty;
        }
        public Customer(string lastName, string firstName, string middleName,
                        string email, string number, DateOnly dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Email = email;
            Number = number;
            DateOfBirth = dateOfBirth;
            DateOfRegistration = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
