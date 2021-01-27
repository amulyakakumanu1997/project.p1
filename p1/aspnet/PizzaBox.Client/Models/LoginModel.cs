using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class LoginModel
    {
        public string CurrentCustomerId { get; set; }
        public List<Customer> AllCustomers { get; set; }

        public Customer NewCustomer {get; set;}

        public Customer OldCustomer {get; set;}
    }
}