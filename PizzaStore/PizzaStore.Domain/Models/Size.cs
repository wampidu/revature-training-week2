namespace PizzaStore.Models.Domain
{
  public class Size
  {
    public string Large { get; set; }
    public string Medium { get; set; }
    public string Small { get; set; }

    public string ReturnSizeL()
    {
      return Large;
    }

    public string ReturnSizeM()
    {
      return Medium;
    }

    public string ReturnSizeS()
    {
      return Small;
    }

    public Size(string size)
    {
      return 
    }
  }
}