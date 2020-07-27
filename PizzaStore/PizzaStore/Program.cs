using System;
using PizzaStore.Domain.Models;
using PizzaStore.Domain;
using System.Collections.Generic;
using PizzaStore.Models.Domain;

namespace Pizzastore
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

      // try
      //  {
      Menu2(startup.CreateOrder(user, store));
      //  }
      //catch(Exception ex)
      // {
      //   System.Console.WriteLine(ex.Message);
      // }
    }
    static void Menu2(Order cart)
    {
      var exit = false;
      var Size = new Size();
      var Crust = new Crust();
      var Topping = new Topping();
      do
      {
        Startup.PrintMenuInitial();
        int select;
        var ToppingSelection = true;
        


        
        int.TryParse(Console.ReadLine(), out select);
        switch (select)
        {
          case 1:
            Startup.PrintMenu1();
            int.TryParse(Console.ReadLine(), out select);
            switch (select)
            {
              case 1: //Cheese Pizza Preset
                Topping.SetTopping("cheese");
                Startup.PrintMenuSize();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Size.SetSize("small");
                    break;
                  case 2:
                    Size.SetSize("medium");
                    break;
                  case 3:
                    Size.SetSize("large");
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Crust.SetCrust("regular");
                    break;
                  case 2:
                    Crust.SetCrust("stuffed");
                    break;
                  case 3:
                    Crust.SetCrust("pan");
                    break;
                }
                //^^Crust Selection
                cart.CreatePizza(Size, Crust, Topping);
                break;
              case 2: //Pepperoni Pizza Preset
                Topping.SetTopping("pepperoni");
                Startup.PrintMenuSize();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Size.SetSize("small");
                    break;
                  case 2:
                    Size.SetSize("medium");
                    break;
                  case 3:
                    Size.SetSize("large");
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Crust.SetCrust("regular");
                    break;
                  case 2:
                    Crust.SetCrust("stuffed");
                    break;
                  case 3:
                    Crust.SetCrust("pan");
                    break;
                }
                //^^Crust Selection
                cart.CreatePizza(Size, Crust, Topping);
                break;
              case 3: //Hawaiian Pizza Preset
                Topping.SetTopping("pineapple");
                Startup.PrintMenuSize();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Size.SetSize("small");
                    break;
                  case 2:
                    Size.SetSize("medium");
                    break;
                  case 3:
                    Size.SetSize("large");
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                  case 1:
                    Crust.SetCrust("regular");
                    break;
                  case 2:
                    Crust.SetCrust("stuffed");
                    break;
                  case 3:
                    Crust.SetCrust("pan");
                    break;
                }
                //^^Crust Selection
                cart.CreatePizza(Size, Crust, Topping);
                break;
              case 4:
                break;
              case 5:
                //cart.CreatePizza("L", "Stuffed", new List<string> { "custom" });
                //System.Console.WriteLine("added Custom Pizza");
                break;

              case 6:
                //var fm = new FileManager();
                //fm.Write(cart);
                //System.Console.WriteLine("Thank you goodbye");
                //exit = true;
                break;
              case 7:
                //var fmr = new FileManager();
                //DisplayCart(fmr.Read());
                break;
            }
            break;
          case 2:
            Startup.PrintMenuSize();
            int.TryParse(Console.ReadLine(), out select);
            switch (select)
            {
              case 1:
                    Size.SetSize("small");
                    break;
              case 2:
                    Size.SetSize("medium");
                    break;
              case 3:
                    Size.SetSize("large");
                    break;
            }
            //^^Size Selection
            Startup.PrintMenuCrust();
            int.TryParse(Console.ReadLine(), out select);
            switch (select)
            {
              case 1:
                    Crust.SetCrust("regular");
                    break;
                  case 2:
                    Crust.SetCrust("stuffed");
                    break;
                  case 3:
                    Crust.SetCrust("pan");
                    break;
            }
            //^^Crust Selection
            Startup.PrintMenuToppings();
            int.TryParse(Console.ReadLine(), out select);
            do
            {
              switch (select)
              {
                case 1:
                  //CustomPizza.Toppings.Add(PepperoniTopping);
                  Topping.SetTopping("pepperoni");
                  break;
                case 2:
                  //CustomPizza.Toppings.Add(HamTopping);
                  Topping.SetTopping("ham");
                  break;
                case 3:
                  //CustomPizza.Toppings.Add(GrPepperTopping);
                  Topping.SetTopping("green pepper");
                  break;
                case 4:
                  //CustomPizza.Toppings.Add(PineappleTopping);
                  Topping.SetTopping("pineapple");
                  break;
                case 5:
                 //CustomPizza.Toppings.Add(SausageTopping);
                  Topping.SetTopping("sausage");
                  break;
                case 6:
                  ToppingSelection = false;
                  break;
              }
            } while (ToppingSelection == true);
            //^^Topping Selection
            cart.CreatePizza(Size, Crust, Topping);
            break;
          case 3:
            DisplayCart(cart);
            break;
        }
        int.TryParse(Console.ReadLine(), out select);


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