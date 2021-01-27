using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly PizzaBoxRepository _ctx;
        public CustomerController(PizzaBoxRepository context)
        {
            _ctx = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var LoginModel = new LoginModel();
            LoginModel.AllCustomers = _ctx.GetCustomers().ToList(); 

            return View("CustomerSelect",LoginModel);
        }
        public IActionResult Welcome(LoginModel LoginModel)
        {
            Customer CurrentCustomer = _ctx.GetCustomer(long.Parse(LoginModel.CurrentCustomerId));
            var customer = new CustomerViewModel();
            customer.CustomerId = CurrentCustomer.EntityId.ToString();
            customer.Name = CurrentCustomer.Name;
            customer.CurrentCustomer = CurrentCustomer;

            TempData.Put<CustomerViewModel>("CurrentCustomer" , customer);
            
            ViewBag.CustomerName = CurrentCustomer.Name;

            customer.Order = new OrderViewModel()
            {
                Stores = _ctx.GetStores().ToList()
            };


            return View("home",customer);
        }

        public IActionResult NewCustomer(LoginModel loginmodel)
        {
            Customer CustomerNew = new Customer();
            CustomerNew.Name = loginmodel.NewCustomer.Name;
            _ctx.AddCustomer(CustomerNew);
            var customer = new CustomerViewModel();
            customer.CustomerId = CustomerNew.EntityId.ToString();
            customer.Name = CustomerNew.Name;
            customer.CurrentCustomer = CustomerNew;
            TempData.Put<CustomerViewModel>("CurrentCustomer" , customer);
            
            ViewBag.CustomerName = CustomerNew.Name;

            customer.Order = new OrderViewModel()
            {
                Stores = _ctx.GetStores().ToList()
            };
            return View("home", customer);
        }

        public IActionResult ReturningCustomer(LoginModel loginmodel)
        {
            Customer CustomerOld = new Customer();
            CustomerOld.Name = loginmodel.OldCustomer.Name;
            _ctx.AddCustomer(CustomerOld);
            var customer = new CustomerViewModel();
            customer.CustomerId = CustomerOld.EntityId.ToString();
            customer.Name = CustomerOld.Name;
            customer.CurrentCustomer = CustomerOld;
            TempData.Put<CustomerViewModel>("CurrentCustomer" , customer);
            
            ViewBag.CustomerName = CustomerOld.Name;

            customer.Order = new OrderViewModel()
            {
                Stores = _ctx.GetStores().ToList()
            };
            return View("home", customer);
        }

    }
        
}