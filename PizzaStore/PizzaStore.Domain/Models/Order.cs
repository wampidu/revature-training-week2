using System;
using System.Collections.Generic;
using PizzaStore.Models.Domain;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public List<Pizza> Pizzas { get; set; }
    public DateTime DateOrdered { get; set; }

    public void CreatePizza(Size size, Crust crust, Topping toppings)
    {
      Pizzas.Add(new Pizza(size, crust, toppings));
    }

    public Order()
    {
      Pizzas = new List<Pizza>();
    }

    public void Add(Pizza pizza)
    {
      Pizzas.Add(pizza);
    }

    public static object GetPropValue(object src, string propname)
    {
      return src.GetType().GetProperty(propname).GetValue(src, null);
    }

  }
}