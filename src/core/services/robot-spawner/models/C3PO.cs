public class C3PO : BaseRobot
{
    
  public C3PO(int id, string model) : base(id, model) { }

  public Func<int> NumberOfRepairs = () => new Random().Next(0, 100);

}

