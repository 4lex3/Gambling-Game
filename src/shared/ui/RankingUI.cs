public class ProfileUI
{

    private static Dictionary<int, ConsoleColor> mostRankedColors = new Dictionary<int, ConsoleColor> {
        {0, ConsoleColor.Magenta},
        {1, ConsoleColor.Cyan},
        {2, ConsoleColor.Yellow}
    };


    private static Dictionary<string, ConsoleColor> modelsColors = new Dictionary<string, ConsoleColor>{
        {"R2D2", ConsoleColor.Yellow},
        {"C3PO", ConsoleColor.Green},
        {"BB8", ConsoleColor.Magenta}
    };


    public static void FindUI(List<GameSession> sessions, string target)
    {
        bool isAnExistingSession = false;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("+------------+----------------------+---------+");
        Console.WriteLine("| POSITION   | SESSION NAME         | POINTS  |");
        Console.WriteLine("+------------+----------------------+---------+");

        for (int i = 0; i < sessions.Count; i++)
        {
            Console.ForegroundColor = mostRankedColors.GetValueOrDefault(i, ConsoleColor.DarkBlue);

            if(sessions[i].Name == target){
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"| {i + 1,-10} | {sessions[i].Name,-20} | {sessions[i].Points,-7} | <- You");
                isAnExistingSession = true;
                Console.ResetColor();
                continue;
            }

            Console.WriteLine($"| {i + 1,-10} | {sessions[i].Name,-20} | {sessions[i].Points,-7} |");
        }

        Console.WriteLine("+------------+----------------------+---------+");

        if(!isAnExistingSession){
            GenericUI.WriteLine("Game session not found! ", ConsoleColor.Red);
        }
        Console.ResetColor();

    }

    // public static void ShowRobots(){

    // }


}
