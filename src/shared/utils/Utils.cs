public class Utils
{


    public static Task AsyncSetInterval(Action action, int time){

        return Task.Run(() => {

            while (true)
            {
                action();
                Thread.Sleep(time);   
            }
        });

    }
    
}
