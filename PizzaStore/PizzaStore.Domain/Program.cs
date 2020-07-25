using System;
using PizzaStore.Domain.Models;
using PizzaStore.Domain;
using System.Collections.Generic;
using PizzaStore.Models.Domain;

namespace Pizzastore.Domain
{
  class Program
  {
    static void Main()
    {
      Welcome();
    }

    static void Welcome()
    {
      Console.WriteLine("Welcome to the Pizza Store.");

      List<Pizza> cart = new List<Pizza>();
      var startup = new PizzaStore.Domain.Startup();
      var user = new User();
      var store = new Store();
      var order = startup.CreateOrder(user, store);

      try
      {
        Menu2(startup.CreateOrder(user, store));
      }
      catch
      {

      }
    }
    static void Menu2(Order cart)
    {
      var SizeL = new Size();
      var crust = new Crust();
      var topping = new Topping();
      var exit = false;
      do
      {
        Startup.PrintMenu();

        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            cart.CreatePizza(size, crust, topping);
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            cart.CreatePizza("L", "Stuffed", new List<string> { "pepperoni" });
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            cart.CreatePizza("L", "Stuffed", new List<string> { "hawaiian" });
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            cart.CreatePizza("L", "Stuffed", new List<string> { "custom" });
            System.Console.WriteLine("added Custom Pizza");
            break;
          case 5:
            DisplayCart(cart);
            break;
          case 6:
            var fm = new FileManager();
            fm.Write(cart);
            System.Console.WriteLine("Thank you goodbye");
            exit = true;
            break;
          case 7:
            var fmr = new FileManager();
            DisplayCart(fmr.Read());
            break;

        }
      } while (!exit);
    }
    static void DisplayCart(Order cart)
    {
      foreach (var pizza in cart.Pizzas)
      {
        System.Console.WriteLine(pizza);
      }

    }
  }
}