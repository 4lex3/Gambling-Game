using System.Threading.Tasks;
using Microsoft.Win32;

public class Game
{

    //? Services
    private RobotSpawnerService<BB8> BB8Generator { get; }
    private RobotSpawnerService<C3PO> C3POGenerator { get; }
    private RobotSpawnerService<R2D2> R2D2Generator { get; }
    private RouletteService RouletteService { get; }


    public Game(
        RobotSpawnerService<BB8> bb8Generator,
        RobotSpawnerService<C3PO> c3poGenerator,
        RobotSpawnerService<R2D2> r2d2Generator,
        RouletteService rouletteService
    )
    {
        BB8Generator = bb8Generator;
        C3POGenerator = c3poGenerator;
        R2D2Generator = r2d2Generator;
        RouletteService = rouletteService;
    }


    public async Task Start()
    {

        // int option = 0;
        // do
        // {

            int option = MenuUI.ShowMenu();
            // HandleMenus(option);

        // } while (option >= 1 && option <= 5);


        // Console.WriteLine($"Exit");
        
    }


    // private void HandleMenus(int option)
    // {

    //     switch (option)
    //     {
    //         case 1:

    //             break;
    //         case 2:
    //             // Save game session
    //             break;
    //         case 3:
    //             // See your position in the ranking
    //             break;
    //         case 4:
    //             // Check your robots
    //             break;
    //         case 5:
    //             // Check your robots
    //             break;

    //         default:
    //             GenericUI.WriteLine("Invalid option, please try again.");
    //             break;

    //     }
    // }


}