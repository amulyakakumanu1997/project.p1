using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
    {
        public string Name { get; set; }
        public List<CrustViewModel> AllCrusts = new List<CrustViewModel>(){
            new CrustViewModel("thin"),
            new CrustViewModel("regular"),
            new CrustViewModel("pan")
        };
        public List<SizeViewModel> AllSizes = new List<SizeViewModel>(){
            new SizeViewModel("small"),
            new SizeViewModel("medium"),
            new SizeViewModel("large")
        };


        public string Crust { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public PizzaViewModel()
        {

        }
        public PizzaViewModel(string name)
        {
            Name = name;
        }
        public PizzaViewModel(string name, string size, string crust)
        {
            Name = name;
            Size = size;
            Crust = crust;
            if (Size.Equals("small"))
            {
                Price = "5";
            }
            else if (Size.Equals("medium"))
            {
                Price = "6";
            }
            else if (Size.Equals("large"))
            {
                Price = "7";
            }
        }
    }
}