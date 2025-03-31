
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
                        2. Save game session
                        3. See your position in the ranking
                        4. Check your robots
                        5. Check your robots
                        
                        Insert your option: 
            ", animationOptionsControl.Token);

            key = Console.ReadKey(true).KeyChar - '0';

            if(!(key >= 1 && key <= 5)){
                animationOptionsControl.Cancel();
                GenericUI.WriteLine($"Invalid number");
                Console.ReadKey();
            }

        } while (!(key >= 1 && key <= 5));


        animationOptionsControl.Cancel();
        return key;
    }



}