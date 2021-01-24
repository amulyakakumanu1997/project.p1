using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class CustomerViewModel
  {
    public string Name { get; set; }
    public string CustomerId { get; set; }
    public OrderViewModel Order { get; set; }
    public string SelectedStoreId { get; set; }
    public Customer CurrentCustomer { get; set; }
    public CustomerViewModel()
    {
      Order = new OrderViewModel();
    }

  }
}