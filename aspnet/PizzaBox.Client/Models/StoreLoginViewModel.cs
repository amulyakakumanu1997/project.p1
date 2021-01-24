using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class StoreLoginViewModel
    {
        public string CurrentStoreName { get; set; }
        public string CurrentStoreId { get; set; }
        public List<Store> AllStores { get; set; }
    }
}