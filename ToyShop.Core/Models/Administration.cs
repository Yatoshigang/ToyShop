using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToyShop.Core.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Login), IsUnique = true)]
    internal class Administration
    {
        public int Id_adm { get; set; }
        public User User { get; set; } = new();
        public int Id_adm_user { get => User.Id_user; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Administration(string lastName, string firstName, string middleName, string email, string login, string password)
        {
            User = new();

            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Email = email;
            Login = login;
            Password = password;
        }
        public Administration() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
            
        }
    }
}
