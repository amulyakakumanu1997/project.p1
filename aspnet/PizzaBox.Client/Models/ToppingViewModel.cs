using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class ToppingViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ToppingViewModel()
        {
            
        }
    }
}