using System.Drawing;

public static class GenericUI 
{


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




}























