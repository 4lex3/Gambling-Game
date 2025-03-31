using System;
using System.Threading;

public static class RouletteUI
{
    private static readonly string[] Symbols = { "🍒", "🍋", "🍉", "7️⃣", "🍊" };

    public static void Spin()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🎰 MÁQUINA TRAGAMONEDAS 🎰");
        Console.WriteLine("Presiona ENTER para girar...");
        Console.ResetColor();
        Console.ReadKey();

        Random random = new Random();
        string[] reels = new string[3];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
                reels[j] = Symbols[random.Next(Symbols.Length)];

            Console.Clear();
            Console.WriteLine("🎰 MÁQUINA TRAGAMONEDAS 🎰");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"|  {reels[0]}  |  {reels[1]}  |  {reels[2]}  |");
            Console.WriteLine("---------------------------");
            Thread.Sleep(150);
        }
    }
}
