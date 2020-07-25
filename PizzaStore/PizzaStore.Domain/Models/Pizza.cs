using System.Collections.Generic;
using System.Text;
using PizzaStore.Models.Domain;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    public List<Topping> Toppings { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    void AddToppings(Topping topping)
    {
      Toppings.Add(topping);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var t in Toppings)
      {
        sb.Append(t);
      }
      return $"{Crust} {Size} {sb}";
    }

    public Pizza(Size size, Crust crust, Topping toppings)
    {
      Crust = crust;
      Size = size;
      Toppings.Add(toppings);
    }

    public Pizza()
    {

    }
  }
}