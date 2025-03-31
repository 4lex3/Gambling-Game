public class RobotSpawnerService <T>  
{
    public List<T> Robots {get;} 

    public RobotSpawnerService(){
        Robots = new List<T>(); 
    }

    public void AddRobot(T newRobot) => Robots.Add(newRobot);
}
