using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PepperoniPizza : APizzaModel
    {
        public PepperoniPizza(Size size, Crust crust)
        {
            AddName("Veggie Pizza");
            AddCrust(crust);
            AddSize(size);
            AddToppings();
            ComputePrice();
        }
        public PepperoniPizza()
        {
            Name = "Veggie Pizza";
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
                new Topping("pepperoni"),
                new Topping("onion"),
                new Topping("olives")
            };
        }
        protected  void AddName(string name)
        {
            Name = name;
        }
    }
}