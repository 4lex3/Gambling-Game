public class SpinRouletteResults {
    public int[] IntegerValues {get; }
    public int Points {get; set;}

    public SpinRouletteResults(int[] results, int points = 0){
        IntegerValues = results;
        Points = points;
    }
}

