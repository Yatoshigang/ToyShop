using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Models
{
    /// <summary>
    /// Класс-модель брендов
    /// </summary>
    public class Brand
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateOnly DateOfOpen { get; set; }
        public string Site { get; set; }

        public Brand(string name, string country, DateOnly dateOfOpen, string site)
        {
            Name = name;
            Country = country;
            DateOfOpen = dateOfOpen;
            Site = site;
        }
        public Brand() : this(string.Empty, string.Empty, DateOnly.MinValue, string.Empty)
        {
            
        }
    }
}
