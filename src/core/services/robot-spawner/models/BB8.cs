public class BB8 : BaseRobot
{

  public float VersionNumber {get; }

  public BB8(int id, string model, float versionNumber = 1) : base(id, model) {
    VersionNumber = versionNumber; 
  }

}