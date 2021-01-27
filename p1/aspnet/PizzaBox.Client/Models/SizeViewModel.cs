using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class SizeViewModel
    {
        public string Name { get; set; }
        public SizeViewModel(string name)
        {
            Name = name;
        }
    }
}