namespace PizzaStore.Models.Domain
{
  public class Size
  {
    public string  name { get; set; }


    public void SetSize(string size)
    {
      name = size;
    }
    public Size()
    {

    }
  }
}