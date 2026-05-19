using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToyShop.Core.Models
{
    /// <summary>
    /// Класс-модель администраторов
    /// </summary>
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Login), IsUnique = true)]
    public class Administration
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Administration(string lastName, string firstName, string middleName, string email, string login, string password)
        {
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

        public override string ToString()
        {
            return $"{this.LastName} {char.ToUpper(this.FirstName[0])}.{char.ToUpper(this.MiddleName[0])}";
        }
    }
}
