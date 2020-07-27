namespace PizzaStore.Models.Domain
{
  public class Crust
  {
    public string  name { get; set; }

    public void SetCrust(string crust)
    {
      name = crust;
    }

    public Crust()
    {

    }
  }
}