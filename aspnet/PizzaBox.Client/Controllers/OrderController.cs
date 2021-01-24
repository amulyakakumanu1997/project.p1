using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly PizzaBoxRepository _ctx;
        public OrderController(PizzaBoxRepository context)
        {
            _ctx = context;
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult StartNewOrder(CustomerViewModel customer)
        {
            //TempData.Put<string>("SelectedStoreId", customer.SelectedStoreId);
            //TempData.Put<string>("CurrentCustomerId", customer.CustomerId);
            TempData.Put<CustomerViewModel>("CurrentCustomer" , customer);
            return View("PrintOrder", customer.Order);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPizza(OrderViewModel order)
        {
            if (TempData.Get<List<PizzaViewModel>>("PizzaList") is not null)
            {
                order.PizzaList = TempData.Get<List<PizzaViewModel>>("PizzaList");
            }

            order.PizzaList.Add(new PizzaViewModel(order.Name, order.Size, order.Crust));

            TempData.Put<List<PizzaViewModel>>("PizzaList", order.PizzaList);
            TempData.Put<CustomerViewModel>("CurrentCustomer", TempData.Get<CustomerViewModel>("CurrentCustomer"));

            return View("PrintOrder", order);

        }
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitOrder(OrderViewModel model)
        {
                model.PizzaList = TempData.Get<List<PizzaViewModel>>("PizzaList");
                TempData.Remove("PizzaList");

                CustomerViewModel customer = TempData.Get<CustomerViewModel>("CurrentCustomer");
                Order order = new Order();
                order.DateModified = System.DateTime.Now;
                order.StoreEntityId = long.Parse(customer.SelectedStoreId);
                order.CustomerEntityId = long.Parse(customer.CustomerId);
                
                foreach(var pizza in model.PizzaList)
                {
                    if(pizza.Name.Equals("PepperoniPizza"))
                    {
                        order.Pizzas.Add(new PepperoniPizza(new Size(pizza.Size),new Crust(pizza.Crust)));
                    }
                    else if(pizza.Name.Equals("VeggiePizza"))
                    {
                        order.Pizzas.Add(new VeggiePizza(new Size(pizza.Size),new Crust(pizza.Crust)));
                    }
                    else if(pizza.Name.Equals("CheesePizza"))
                    {
                        order.Pizzas.Add(new CheesePizza(new Size(pizza.Size),new Crust(pizza.Crust)));
                    }

                    else if(pizza.Name.Equals("ChickenPizza"))
                    {
                        order.Pizzas.Add(new ChickenPizza(new Size(pizza.Size),new Crust(pizza.Crust)));
                    }
                    else if(pizza.Name.Equals("MargharitaPizza"))
                    {
                        order.Pizzas.Add(new MargharitaPizza(new Size(pizza.Size),new Crust(pizza.Crust)));
                    }

                }
                
                order.ComputePrice();
                

                _ctx.AddOrder(order);
                _ctx.Update();

                return View("OrderPass");
        }
    }
}