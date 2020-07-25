using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class User
  {
    public List<Order> Orders { get; set; }
    public string Name { get; set; }

    public User()
    {
      Orders = new List<Order>();
    }

    public string SetName(string name)
    {
      Name = name;
      return name;
    }
  }
}