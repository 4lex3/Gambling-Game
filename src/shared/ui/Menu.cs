
public class MenuUI()
{
    public static string Banner = @"


                        '########::'####:'########::'########::::::::::::::::'########:::'#######::'##::::'##:'##:::::::'########:'########:'########:'########:
                        ##.... ##:. ##:: ##.... ##: ##.....::::::::::::::::: ##.... ##:'##.... ##: ##:::: ##: ##::::::: ##.....::... ##..::... ##..:: ##.....::
                        ##:::: ##:: ##:: ##:::: ##: ##:::::::::::::::::::::: ##:::: ##: ##:::: ##: ##:::: ##: ##::::::: ##:::::::::: ##::::::: ##:::: ##:::::::
                        ########::: ##:: ########:: ######::::::'#######:::: ########:: ##:::: ##: ##:::: ##: ##::::::: ######:::::: ##::::::: ##:::: ######:::
                        ##.....:::: ##:: ##.....::: ##...:::::::........:::: ##.. ##::: ##:::: ##: ##:::: ##: ##::::::: ##...::::::: ##::::::: ##:::: ##...::::
                        ##::::::::: ##:: ##:::::::: ##:::::::::::::::::::::: ##::. ##:: ##:::: ##: ##:::: ##: ##::::::: ##:::::::::: ##::::::: ##:::: ##:::::::
                        ##::::::::'####: ##:::::::: ########:::::::::::::::: ##:::. ##:. #######::. #######:: ########: ########:::: ##::::::: ##:::: ########:
                        ..:::::::::....::..:::::::::........:::::::::::::::::..:::::..:::.......::::.......:::........::........:::::..::::::::..:::::........::

                        ================ 🎲    🎰    ♠️    ♥️    ♦️    ♣️    🎲    🎰    🃏    ♠️    ♥️    ♦️    ♣️    🎲    🎰    🃏    ♠️    ♥️    ♦️    ♣ ===============

    ";


    public static void ShowBanner()
    {

        CancellationTokenSource animationBannerControl = new CancellationTokenSource();

        GenericUI.FlashingText($@"
                        {Banner}
                        Press button to continue .............
        ", animationBannerControl.Token);


        Console.ReadKey();
        animationBannerControl.Cancel();

        Console.Clear();
    }

    public static int ShowMenu()
    {

        ShowBanner();

        CancellationTokenSource animationOptionsControl = new CancellationTokenSource();
        

        int key = 0;  
        do
        {
            animationOptionsControl = new CancellationTokenSource();
            GenericUI.FlashingText($@"
                        {Banner}

                        1. Spin Roulette 
                        2. See your position in the ranking
                        3. Check your robots
                        4. Exit
                        
                        Insert your option: 
            ", animationOptionsControl.Token);

            key = Console.ReadKey(true).KeyChar - '0';

            if(!(key >= 1 && key <= 4)){
                animationOptionsControl.Cancel();
                GenericUI.WriteLine($"Invalid number", ConsoleColor.Red);
                Console.ReadKey();
            }

        } while (!(key >= 1 && key <= 4));


        animationOptionsControl.Cancel();
        return key;
    }

}