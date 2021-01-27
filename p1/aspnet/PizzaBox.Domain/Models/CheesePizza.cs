using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CheesePizza : APizzaModel
    {
        public CheesePizza(Size size, Crust crust)
        {
            AddName("Cheese Pizza");
            AddCrust(crust);
            AddSize(size);
            AddToppings();
            ComputePrice();
        }
        public CheesePizza()
        {
            Name = "Cheese Pizza";
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
                new Topping("cheese")
            };
        }
        protected  void AddName(string name)
        {
            Name = name;
        }
    }
}