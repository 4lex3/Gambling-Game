using System.Net.WebSockets;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Clear();

        //? Services (Dependency Injection):
        RobotSpawnerService<BB8> BB8Spawner = new RobotSpawnerService<BB8>();
        RobotSpawnerService<C3PO> C3P0Spawner = new RobotSpawnerService<C3PO>();
        RobotSpawnerService<R2D2> R2D2Spawner = new RobotSpawnerService<R2D2>();
        
        RouletteService roulette = new RouletteService(BB8Spawner, C3P0Spawner, R2D2Spawner);
        SessionController sessionController = new SessionController();


        //? Main Game 
        Game game = new Game( BB8Spawner, C3P0Spawner, R2D2Spawner, roulette, sessionController );

        await game.Start(); 
    

    }

        

}
