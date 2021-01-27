using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaBoxRepository
    {
        private PizzaBoxContext _ctx;
        private int MyProperty { get; set; }
        public Customer  CurrentCustomer{ get; set; }

        public PizzaBoxRepository(PizzaBoxContext context)
        {
            _ctx = context;
        }
        public IEnumerable<Store> GetStores()
        {
            return _ctx.Store;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _ctx.Customer;
        }
        public Customer GetCustomer(long id)
        {
            return _ctx.Customer.Include(customer => customer.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Crust).
            Include(customer => customer.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Size).
            Include(customer => customer.Orders).ThenInclude(Order => Order.Pizzas).ThenInclude(pizza => pizza.Toppings).
            FirstOrDefault(customer => customer.EntityId == id);
        }

        public Customer GetCustomer(string name)
        {
            return _ctx.Customer.Include(customer => customer.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Crust).
            Include(customer => customer.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Size).
            Include(customer => customer.Orders).ThenInclude(Order => Order.Pizzas).ThenInclude(pizza => pizza.Toppings).
            FirstOrDefault(customer => customer.Name == name);
        }
        
        public Store GetStore(string id)
        {
            return _ctx.Store.Include(store => store.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Crust).
            Include(store => store.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Size).
            Include(store => store.Orders).ThenInclude(Order => Order.Pizzas).ThenInclude(pizza => pizza.Toppings).
            FirstOrDefault(Store => Store.EntityId == long.Parse(id));
        }
        public void AddOrder(Order order)
        {
            _ctx.Order.Add(order);
        }

        public void AddCustomer(Customer customer)
        {
            _ctx.Customer.Add(customer);
            _ctx.SaveChanges();
        }
        public void Update()
        {
            _ctx.SaveChanges();
        }
    }
}