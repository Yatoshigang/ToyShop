using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToyShop.Core.Models
{
    [Index(nameof(Name_cat), IsUnique = true)]
    public class Category
    {
        public int Id_cat { get; set; }
        [Required]
        public string Name_cat {  get; set; }

        public Category(string name)
        {
            Name_cat = name;
        }
        public Category() : this(string.Empty)
        {
            
        }
    }
}
