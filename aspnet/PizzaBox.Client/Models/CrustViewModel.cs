namespace PizzaBox.Client.Models
{
  public class CrustViewModel
    {
        public string Name { get; set; }

        public CrustViewModel(string name)
        {
            Name = name;
        }
    }
}