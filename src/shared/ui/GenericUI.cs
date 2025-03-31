public static class GenericUI 
{

    public static List<ConsoleColor> Colors = new List<ConsoleColor>
    {
        ConsoleColor.Black,
        ConsoleColor.DarkBlue,
        ConsoleColor.DarkGreen,
        ConsoleColor.DarkCyan,
        ConsoleColor.DarkRed,
        ConsoleColor.DarkMagenta,
        ConsoleColor.DarkYellow,
        ConsoleColor.Gray,
        ConsoleColor.DarkGray,
        ConsoleColor.Blue,
        ConsoleColor.Green,
        ConsoleColor.Cyan,
        ConsoleColor.Red,
        ConsoleColor.Magenta,
        ConsoleColor.Yellow,
        ConsoleColor.White
    };


    public static void WriteLine(string text, ConsoleColor textColor = ConsoleColor.Green, int sleep = 14)
    {

        Console.ForegroundColor = textColor;

        for (int i = 0; i < text.Length; i++)
        {
            Console.Write($"{text[i]}");
            Thread.Sleep(sleep);
        }

        Console.ResetColor();
    }



    public static string TextInput(string label, ConsoleColor consoleColor = ConsoleColor.DarkBlue)
    {

        string value;

        while (true)
        {
            try
            {
                WriteLine($"{label}", consoleColor); value = Console.ReadLine()!;
                if(value == "") throw new NullReferenceException("This value is not empty! ");
                return value;
            }
            catch (NullReferenceException e)
            {
                WriteLine(e.Message, ConsoleColor.Red);
                Console.ReadKey();
            }
        }

    }

    public static Task FlashingText(string text, CancellationToken AnimationControl){

        return Task.Run(() => {

            int counter = 0;

            while (!AnimationControl.IsCancellationRequested)
            {
                Console.Clear();

                Console.ForegroundColor = Colors[counter];
                Console.WriteLine(text);
                Console.ResetColor();                    

                if (counter >= Colors.Count - 1) counter = 0;
                
                counter++;
                Thread.Sleep(150);
            }
            
        });

    }

    public static void ShowLoader()
    {
        string[] animationFrames = { "|", "/", "-", "\\" };
        int frameIndex = 0;
        int progressBarWidth = 50;
        int progress = 0;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Loading ...");

        while (progress <= progressBarWidth)
        {
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{new string('#', progress)}{new string(' ', progressBarWidth - progress)}]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" {animationFrames[frameIndex]}");

            frameIndex = (frameIndex + 1) % animationFrames.Length;

            progress++;
            Thread.Sleep(100); 
        }

        Console.SetCursorPosition(0, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[{new string('#', progressBarWidth)}] ¡Done!");
        Console.ResetColor();
    }

}