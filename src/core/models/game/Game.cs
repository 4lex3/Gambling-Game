public class Game
{

    //? Services
    private RobotSpawnerService<BB8> BB8Generator { get; }
    private RobotSpawnerService<C3PO> C3POGenerator { get; }
    private RobotSpawnerService<R2D2> R2D2Generator { get; }
    private RouletteService RouletteService { get; }
    private SessionController SessionController { get; }
    private GameSession currentSession = null;

    public Game(
        RobotSpawnerService<BB8> bb8Generator,
        RobotSpawnerService<C3PO> c3poGenerator,
        RobotSpawnerService<R2D2> r2d2Generator,
        RouletteService rouletteService,
        SessionController sessionController
    )
    {
        BB8Generator = bb8Generator;
        C3POGenerator = c3poGenerator;
        R2D2Generator = r2d2Generator;
        RouletteService = rouletteService;
        SessionController = sessionController;
    }


    public async Task Start()
    {

        int option = 0;

        do
        {

            option = MenuUI.ShowMenu();
            if (option == 4) break;
            await HandleMenus(option);

        } while (true);

        GenericUI.WriteLine($"Exit.. :3");
    }


    private async Task HandleMenus(int option)
    {


        switch (option)
        {
            case 1:

                string name = GenericUI.TextInput("Insert your name: "); currentSession = SessionController.CreateGameSession(name);

                for (int i = 0; i < 10; i++)
                {
                    var rouletteResultsTask = RouletteService.SpinRoulette();

                    RouletteUI.SpinAnimation(currentSession.Points);

                    SpinRouletteResults results = await rouletteResultsTask;
                    RouletteUI.ShowRouletteResults(results.IntegerValues, currentSession.Points);

                    currentSession.Points += results.Points;

                    GenericUI.WriteLine($"---------- Press any key to pull again - Round: {i + 1} ----------", ConsoleColor.Yellow);
                    Console.ReadKey();
                }

                SessionController.SortInRanked(currentSession);
                break;

            case 2:

                string target = GenericUI.TextInput("Enter your name to search: ");
                Console.Clear();
                var loader = GenericUI.ShowLoader();
                var sessionTask = SessionController.GetGameSessions();

                await loader;
                List<GameSession> sessions = await sessionTask;

                Console.Clear();
                ProfileUI.FindUI(sessions, target);
                GenericUI.WriteLine("\n------------- Press any key to exit ----------------", ConsoleColor.Yellow);
                Console.ReadKey();

                break;

            case 3:

                Console.Clear();
                if (currentSession == null)
                {
                    GenericUI.WriteLine("You need to create a game session first!!! ", ConsoleColor.Red);
                    break;
                }

                GenericUI.WriteLine("R2D2 Warehouse: \n", ConsoleColor.Magenta);
                BB8Generator.Robots.ForEach(robot => robot.ShowData());
                GenericUI.WriteLine("\n----------------------------------------------------------\n");

                GenericUI.WriteLine("C3P0 Warehouse: \n", ConsoleColor.Cyan);
                C3POGenerator.Robots.ForEach(robot => robot.ShowData());
                GenericUI.WriteLine("\n----------------------------------------------------------\n");

                GenericUI.WriteLine("C3P0 Warehouse: \n", ConsoleColor.White);
                R2D2Generator.Robots.ForEach(robot => robot.ShowData());


                GenericUI.WriteLine("\n------------- Press any key to exit ----------------", ConsoleColor.Yellow);
                Console.ReadKey();
                break;
        }

    }
}