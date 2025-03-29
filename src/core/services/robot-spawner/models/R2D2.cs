public class R2D2 : BaseRobot
{

  public int VersionNumber {get; }
  
  public R2D2(int id, string model, int versionNumber = 1) : base(id, model) {
    VersionNumber = versionNumber; 
  }

  public Func<int> NumberOfBattles = () => new Random().Next(0, 100);

}
