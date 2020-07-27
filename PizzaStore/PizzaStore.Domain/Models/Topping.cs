using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Topping
  {
    public string  name { get; set; }

    public void SetTopping(string toppingname)
    {
      name = toppingname;
    }
    public Topping()
    {

    }
  }
}