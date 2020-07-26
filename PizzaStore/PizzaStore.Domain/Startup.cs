using System;
using PizzaStore.Domain.Models;
using PizzaStore.Domain;

namespace PizzaStore.Domain
{
  public class Startup
  {
    public static void PrintMenu1()
    {
      System.Console.WriteLine("Select 1 for Cheese Pizza");
      System.Console.WriteLine("Select 2 for Pepperoni Pizza");
      System.Console.WriteLine("Select 3 for Hawaiian Pizza");
      System.Console.WriteLine("Select 4 for Custom Pizza");
      System.Console.WriteLine("Select 5 to exit");
      System.Console.WriteLine();
    }

    public static void PrintMenuInitial()
    {
      System.Console.WriteLine("Select 1 for Preset Pizza Options");
      System.Console.WriteLine("Select 2 for Custom Pizza");
      System.Console.WriteLine("Select 3 to display your cart");
      System.Console.WriteLine();
    }

    public static void PrintMenuSize()
    {
      System.Console.WriteLine("Please choose what size pizza you want:");
      System.Console.WriteLine("Select 1 for small");
      System.Console.WriteLine("Select 2 for medium");
      System.Console.WriteLine("Select 3 for large");
      System.Console.WriteLine();
    }

    public static void PrintMenuCrust()
    {
      System.Console.WriteLine("Please choose what type of crust you want:");
      System.Console.WriteLine("Select 1 for regular");
      System.Console.WriteLine("Select 2 for stuffed");
      System.Console.WriteLine("Select 3 for pan");
      System.Console.WriteLine();
    }

    public static void PrintMenuToppings()
    {
      System.Console.WriteLine("Please choose what toppings you would like on your pizza:");
      System.Console.WriteLine("Select 1 for pepperoni");
      System.Console.WriteLine("Select 2 for ham");
      System.Console.WriteLine("Select 3 for green peppers");
      System.Console.WriteLine("Select 4 for pineapple");
      System.Console.WriteLine("Select 5 for sausage");
      System.Console.WriteLine("Select 6 to finish");
      System.Console.WriteLine();
    }
    public Order CreateOrder(User user, Store store)
    {
      try
      {
        var order = new Order();
        user.Orders.Add(order);
        store.Orders.Add(order);
        return order;
      }
      catch(Exception e)
      {
        System.Console.WriteLine(e.Message);
        throw new System.Exception("something went wrong creating the order in Starter.cs");
      }
    }
  }
}