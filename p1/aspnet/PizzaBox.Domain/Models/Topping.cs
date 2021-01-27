using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AEntity
    {
        public string Name { get; set; }

        public Topping() 
        {
            Name = "";
        }
        public Topping(string name)
        {
            Name = name;
        }
    }
}
