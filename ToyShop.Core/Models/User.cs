using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToyShop.Core.Models
{
    /// <summary>
    /// Класс-модель пользователей
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Sale> sales = new();
        public User(string lastName, string firstName, string middleName, string email, string login, string password)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Email = email;
            Login = login;
            Password = password;

            sales = new();
        }
        public User() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
            
        }
    }
}
