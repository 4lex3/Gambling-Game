using System.Net.WebSockets;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        Console.Clear();

        //? Services (Dependency Injection):
        RobotSpawnerService<BB8> BB8Spawner = new RobotSpawnerService<BB8>();
        RobotSpawnerService<C3PO> C3P0Spawner = new RobotSpawnerService<C3PO>();
        RobotSpawnerService<R2D2> R2D2Spawner = new RobotSpawnerService<R2D2>();
        
        RouletteService roulette = new RouletteService(BB8Spawner, C3P0Spawner, R2D2Spawner);


        //? Main Game 
        Game game = new Game( BB8Spawner, C3P0Spawner, R2D2Spawner, roulette );
        game.Start(); 

        



        



        // Console.WriteLine($"Points {results.Points}");
        

        // foreach (var item in results.IntegerValues) Console.WriteLine($"{item}");
        


        // Console.WriteLine($"------- BB8 -------");
        
        // foreach (var item in BB8Spawner.Robots)
        // {
        //     item.ShowData();
        // }

        // Console.WriteLine($"------- C3PO -------");
        
        //  foreach (var item in C3P0pawner.Robots)
        // {
        //     item.ShowData();
        // }


        // Console.WriteLine($"------- R2D2 -------");
        //   foreach (var item in R2D2Spawner.Robots)
        // {
        //     item.ShowData();
        // }

     


        // // foreach (int item in response.Results)
        // // {
        // //     Console.WriteLine($"{item}");
        // // }


        

    
    }


    // public static async Task TareaRandom(){

    //     Console.WriteLine($"Cargando..");
    //     await Task.Delay(3000);

    //     Console.WriteLine($"Terminado :3");
        
    // }


}
