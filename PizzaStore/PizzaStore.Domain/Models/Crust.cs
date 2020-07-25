namespace PizzaStore.Models.Domain
{
  public class Crust
  {
    public string Regular { get; set; }
    public string Stuffed { get; set; }
    public string Pan { get; set; }

    public string ReturnCrustReg()
    {
      return Regular;
    }

    public string ReturnCrustStuf()
    {
      return Stuffed;
    }

    public string ReturnCrustPan()
    {
      return Pan;
    }
  }
}