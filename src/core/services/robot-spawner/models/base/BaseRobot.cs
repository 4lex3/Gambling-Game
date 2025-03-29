public abstract class BaseRobot
{
    public int Id {get; }
    public DateTime CreateDate {get; }
    public string Model {get; }



    public BaseRobot (int id, string model) { 
        Id = id;
        Model = model;
        CreateDate = DateTime.Now;
    }


    public void ShowData(){ 
        GenericUI.WriteLine($"Robot:{Id}\n");
        GenericUI.WriteLine($"Model:{Model}\n");
        GenericUI.WriteLine($"CreateDate:{CreateDate}\n");
    }

}
