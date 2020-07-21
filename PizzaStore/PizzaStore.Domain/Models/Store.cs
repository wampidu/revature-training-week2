using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class PizzaStore
  {
    public List<Order> Orders { get; set; }
    public string Name { get; set; }

    public Order CreateOrder()
    {
      return new Order();
    }
  }
}