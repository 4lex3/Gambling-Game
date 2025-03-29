using System.Net.WebSockets;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Clear();

        //? Services (Dependency Injection):
        RobotSpawnerService<BB8> BB8Spawner = new RobotSpawnerService<BB8>();
        RobotSpawnerService<C3PO> C3P0pawner = new RobotSpawnerService<C3PO>();
        RobotSpawnerService<R2D2> R2D2Spawner = new RobotSpawnerService<R2D2>();
        
        RouletteService roulette = new RouletteService(BB8Spawner, C3P0pawner, R2D2Spawner);

        SpinRouletteResults results = await roulette.SpinRoulette();
        roulette.MapRobots(results);



        Console.WriteLine($"Points {results.Points}");
        

        foreach (var item in results.IntegerValues) Console.WriteLine($"{item}");
        

        foreach (var item in BB8Spawner.Robots)
        {
            item.ShowData();
        }

        Console.WriteLine($"-------");
        
         foreach (var item in C3P0pawner.Robots)
        {
            item.ShowData();
        }


        Console.WriteLine($"-------");
          foreach (var item in R2D2Spawner.Robots)
        {
            item.ShowData();
        }

     


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
