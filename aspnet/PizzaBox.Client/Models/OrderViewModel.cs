using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public string Name { get; set; }
    public string Size { get; set;}
    public string Crust { get; set; }
    public List<PizzaViewModel> Pizzas { get; set; }
    public List<Store> Stores { get; set; }
    public PizzaViewModel Pizza { get; set; }
    public List<PizzaViewModel> PizzaList { get; set; }
    [Required]
    public string Store { get; set; }
    public OrderViewModel()
    {
      Pizzas = new List<PizzaViewModel>(){
        new PizzaViewModel("PepperoniPizza"),
        new PizzaViewModel("VeggiePizza"),
        new PizzaViewModel("CheesePizza"),
        new PizzaViewModel("MargharitaPizza"),
        new PizzaViewModel("ChickenPizza")
      };
      PizzaList = new List<PizzaViewModel>();
      Pizza = new PizzaViewModel();
    }  
  }
}
