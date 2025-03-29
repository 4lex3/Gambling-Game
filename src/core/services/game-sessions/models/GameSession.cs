public class GameSession
{
    public int Id {get; }
    public string Name {get; set;}     
    public int Points {get; set;}      


    public GameSession(int id, string name, int points) {
        Id = id;
        Name = name;     
        Points = points;    
    }

}