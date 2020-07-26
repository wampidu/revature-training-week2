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
      var exit = false;
      do
      {
        //Initialize Toppings
        var CheeseTopping = new Topping();
        var PepperoniTopping = new Topping();
        var PineappleTopping = new Topping();
        var HamTopping = new Topping();
        var GrPepperTopping = new Topping();
        var SausageTopping = new Topping();
        //Initialize Crusts
        var RegCrust = new Crust();
        var StuffedCrust = new Crust();
        var PanCrust = new Crust();
        //Initialize Sizes
        var Small = new Size();
        var Med = new Size();
        var Large = new Size();
        int select;
        //Initialize Topping Selection argument
        var ToppingSelection = true;
        int.TryParse(Console.ReadLine(), out select);
        Startup.PrintMenuInitial();
        switch (select)
        {
          case 1:
            Startup.PrintMenu1();
            int.TryParse(Console.ReadLine(), out select);
            switch (select)
            {
              case 1: //Cheese Pizza Preset
                var CheesePizza = new Pizza();
                Startup.PrintMenuSize();
                //var CheeseTopping = new Topping();
                CheesePizza.Toppings.Add(CheeseTopping);
                int.TryParse(Console.ReadLine(), out select);
                switch(select) 
                {
                  case 1: 
                    //var Small = new Size();
                    CheesePizza.Size = Small;
                    break;
                  case 2:
                    //var Med = new Size();
                    CheesePizza.Size = Med;
                    break;
                  case 3:
                    //var Large = new Size();
                    CheesePizza.Size = Large;
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch(select)
                {
                  case 1: 
                    //var RegCrust = new Crust();
                    CheesePizza.Crust = RegCrust;
                    break;
                  case 2:
                    //var StuffedCrust = new Crust();
                    CheesePizza.Crust = StuffedCrust;
                    break;
                  case 3:
                    //var PanCrust = new Crust();
                    CheesePizza.Crust = PanCrust;
                    break;
                }
                //^^Crust Selection
                cart.Add(CheesePizza);
                break;
              case 2: //Pepperoni Pizza Preset
                var PepperoniPizza = new Pizza();
                Startup.PrintMenuSize();
                //var CheeseTopping = new Topping();
                PepperoniPizza.Toppings.Add(CheeseTopping);
                PepperoniPizza.Toppings.Add(PepperoniTopping);
                int.TryParse(Console.ReadLine(), out select);
                switch(select) 
                {
                  case 1: 
                    //var Small = new Size();
                    PepperoniPizza.Size = Small;
                    break;
                  case 2:
                    //var Med = new Size();
                    PepperoniPizza.Size = Med;
                    break;
                  case 3:
                    //var Large = new Size();
                    PepperoniPizza.Size = Large;
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch(select)
                {
                  case 1: 
                    //var RegCrust = new Crust();
                    PepperoniPizza.Crust = RegCrust;
                    break;
                  case 2:
                    //var StuffedCrust = new Crust();
                    PepperoniPizza.Crust = StuffedCrust;
                    break;
                  case 3:
                    //var PanCrust = new Crust();
                    PepperoniPizza.Crust = PanCrust;
                    break;
                }
                //^^Crust Selection
                cart.Add(PepperoniPizza);
                break;
              case 3: //Hawaiian Pizza Preset
                var HawaiianPizza = new Pizza();
                Startup.PrintMenuSize();
                //var CheeseTopping = new Topping();
                HawaiianPizza.Toppings.Add(CheeseTopping);
                HawaiianPizza.Toppings.Add(PineappleTopping);
                int.TryParse(Console.ReadLine(), out select);
                switch(select) 
                {
                  case 1: 
                    //var Small = new Size();
                    HawaiianPizza.Size = Small;
                    break;
                  case 2:
                    //var Med = new Size();
                    HawaiianPizza.Size = Med;
                    break;
                  case 3:
                    //var Large = new Size();
                    HawaiianPizza.Size = Large;
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch(select)
                {
                  case 1: 
                    //var RegCrust = new Crust();
                    HawaiianPizza.Crust = RegCrust;
                    break;
                  case 2:
                    //var StuffedCrust = new Crust();
                    HawaiianPizza.Crust = StuffedCrust;
                    break;
                  case 3:
                    //var PanCrust = new Crust();
                    HawaiianPizza.Crust = PanCrust;
                    break;
                }
                //^^Crust Selection
                cart.Add(HawaiianPizza);
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
                var CustomPizza = new Pizza();
                Startup.PrintMenuSize();
                int.TryParse(Console.ReadLine(), out select);
                switch(select) 
                {
                  case 1: 
                    //var Small = new Size();
                    CustomPizza.Size = Small;
                    break;
                  case 2:
                    //var Med = new Size();
                    CustomPizza.Size = Med;
                    break;
                  case 3:
                    //var Large = new Size();
                    CustomPizza.Size = Large;
                    break;
                }
                //^^Size Selection
                Startup.PrintMenuCrust();
                int.TryParse(Console.ReadLine(), out select);
                switch(select)
                {
                  case 1: 
                    //var RegCrust = new Crust();
                    CustomPizza.Crust = RegCrust;
                    break;
                  case 2:
                    //var StuffedCrust = new Crust();
                    CustomPizza.Crust = StuffedCrust;
                    break;
                  case 3:
                    //var PanCrust = new Crust();
                    CustomPizza.Crust = PanCrust;
                    break;
                }
                //^^Crust Selection
                Startup.PrintMenuToppings();
                int.TryParse(Console.ReadLine(), out select);
                do
                {
                switch(select)
                {
                  case 1:
                    CustomPizza.Toppings.Add(PepperoniTopping);
                    break;
                  case 2:
                    CustomPizza.Toppings.Add(HamTopping);
                    break;
                  case 3:
                    CustomPizza.Toppings.Add(GrPepperTopping);
                    break;
                  case 4:
                    CustomPizza.Toppings.Add(PineappleTopping);
                    break;
                  case 5:
                    CustomPizza.Toppings.Add(SausageTopping);
                    break;
                  case 6:
                    ToppingSelection = false;
                    break;
                }
                } while (ToppingSelection == true);
                //^^Topping Selection
                cart.Add(CustomPizza);
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