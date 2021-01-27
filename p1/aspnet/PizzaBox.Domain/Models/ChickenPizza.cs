using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChickenPizza : APizzaModel
    {
        public ChickenPizza(Size size, Crust crust)
        {
            AddName("Chicken Pizza");
            AddCrust(crust);
            AddSize(size);
            AddToppings();
            ComputePrice();
        }
        public ChickenPizza()
        {
            Name = "Chicken Pizza";
            Crust = new Crust();
            Size = new Size();
            Toppings = new List<Topping>(){
                new Topping(),
                new Topping(),
                new Topping()
            };
        }
        public void AddCrust(Crust crust)
        {
            Crust = crust;
        }

        public void AddSize(Size size)
        {
            Size = size;
        }

        protected  void AddToppings()
        {
            Toppings = new List<Topping>(){
                new Topping("cheese"),
                new Topping("peppers"),
                new Topping("onion"),
                new Topping("chicken")
            };
        }
        protected  void AddName(string name)
        {
            Name = name;
        }
    }
}