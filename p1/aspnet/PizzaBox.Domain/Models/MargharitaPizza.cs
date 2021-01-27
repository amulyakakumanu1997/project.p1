using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MargharitaPizza : APizzaModel
    {
        public MargharitaPizza(Size size, Crust crust)
        {
            AddName("Margharita Pizza");
            AddCrust(crust);
            AddSize(size);
            AddToppings();
            ComputePrice();
        }
        public MargharitaPizza()
        {
            Name = "Margharita Pizza";
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
                new Topping("basil")
            };
        }
        protected  void AddName(string name)
        {
            Name = name;
        }
    }
}