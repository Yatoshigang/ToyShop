using System;
using System.Collections.Generic;
using System.Text;

namespace ToyShop.Core.Models
{
    public class Supplier
    {
        public int Id_sup { get; set; }
        public string Name_sup { get; set; }
        public string Country_sup { get; set; }
        public string Number { get; set; }

        public Supplier(string name, string country, string number)
        {
            Name_sup = name;
            Country_sup = country;
            Number = number;
        }
        public Supplier() : this(string.Empty, string.Empty, string.Empty)
        {
            
        }
    }
}
