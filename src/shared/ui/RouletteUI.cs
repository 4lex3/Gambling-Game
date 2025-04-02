public static class RouletteUI
{
    private static readonly List<string> symbols = new List<string>() { "🍒", "🍋", "🍉", "7️⃣", "🍊", "🍓", "🍍", "🍉", "🍇" };
    private static readonly Dictionary<int, string> SymbolMap = new Dictionary<int, string>
    {
        { 1, "🍒" },
        { 2, "🍉" },
        { 3, "7️⃣" },
    };


    public static void SpinAnimation()
    {
        Console.Clear();

        for (int i = 0; i < 30; i++)
        {
            RandomSortList(symbols);
            ShowTable(symbols);
            Thread.Sleep(100);
        }

    }

    public static void ShowRouletteResults(int[] results)
    {
        Console.Clear();

        List<string> values = new List<string>(symbols);

        for (int i = 0; i < 3 && i < results.Length; i++)
        {
            if (SymbolMap.ContainsKey(results[i]))
            {
                values[3 + i] = SymbolMap[results[i]]; 
            }
        }

        ShowTable(values);
        Console.ReadKey();
    }

    public static void RandomSortList(List<string> list)
    {
        Random rand = new Random();

        int n = list.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);

            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    private static void ShowTable(List<string> values)
    {

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔═══════╦═══════╦═══════╗");
        Console.WriteLine($"║   {values[0]}  ║   {values[1]}  ║   {values[2]}  ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╠═══════╬═══════╬═══════╣");
        Console.WriteLine($"║   {values[3]}   ║   {values[4]}  ║   {values[5]}  ║");
        Console.WriteLine("╠═══════╬═══════╬═══════╣");
        Console.ResetColor();
        ;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"║   {values[6]}  ║   {values[7]}  ║   {values[8]}  ║");
        Console.WriteLine("╚═══════╩═══════╩═══════╝");
        Console.ResetColor();
    }
}
