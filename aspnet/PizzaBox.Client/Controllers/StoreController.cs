using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        private readonly PizzaBoxRepository _ctx;
        public StoreController(PizzaBoxRepository context)
        {
            _ctx = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var StoreLoginModel = new StoreLoginViewModel();
            StoreLoginModel.AllStores = _ctx.GetStores().ToList();

            return View("StoreSelect", StoreLoginModel);
        }
        public IActionResult Welcome(StoreLoginViewModel LoginModel)
        {
            var StoreModel = new StoreViewModel();
            StoreModel.CurrentStore =  _ctx.GetStore(LoginModel.CurrentStoreId);
            StoreModel.Name = StoreModel.CurrentStore.Name;
            StoreModel.StoreId = StoreModel.CurrentStore.EntityId.ToString();
            foreach(var order in StoreModel.CurrentStore.Orders)
            {
                StoreModel.TotalRevenue += order.TotalPrice;
            }

            return View("Home" , StoreModel);
        }
    }
}
