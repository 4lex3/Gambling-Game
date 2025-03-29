using Newtonsoft.Json;

public class RouletteService : OnInit
{
    private const string rouletteEndpoint = "https://www.randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3";

    private RobotSpawnerService<BB8> BB8Generator { get; }
    private RobotSpawnerService<C3PO> C3POGenerator { get; }
    private RobotSpawnerService<R2D2> R2D2Generator { get; }

    private Dictionary<int, Action> robotsMap;

    public RouletteService(
        RobotSpawnerService<BB8> bb8Generator,
        RobotSpawnerService<C3PO> c3poGenerator,
        RobotSpawnerService<R2D2> r2d2Generator
    )
    {
        BB8Generator = bb8Generator;
        C3POGenerator = c3poGenerator;
        R2D2Generator = r2d2Generator;
    }

    protected override void OnInitialize()
    {
        robotsMap = new Dictionary<int, Action> {
            { 1, () => BB8Generator.AddRobot(new BB8(BB8Generator.Robots.Count + 1, "BB8", 1))},
            { 2, () => C3POGenerator.AddRobot(new C3PO(C3POGenerator.Robots.Count + 1, "C3PO"))},
            { 3, () => R2D2Generator.AddRobot(new R2D2(R2D2Generator.Robots.Count + 1, "R2D2"))}
        };
    }

    public async Task<SpinRouletteResults> SpinRoulette()
    {

        HttpClient http = new HttpClient();
        HttpResponseMessage response = await http.GetAsync(rouletteEndpoint);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        int[] parsedData = JsonConvert.DeserializeObject<int[]>(responseBody);

        SpinRouletteResults results = new SpinRouletteResults(parsedData, CalculatePoints(parsedData));

        return results;
    }

    public void MapRobots(SpinRouletteResults results) {
        foreach (int number in results.IntegerValues) robotsMap[number]();
    }

    private int CalculatePoints(int[] results){

        int maxResults  = results
                          .GroupBy(n => n)
                          .Select( g => new { Number = g.Key, Quantity = g.Count() })
                          .OrderByDescending(g => g.Quantity)
                          .First().Quantity;
        

        if(maxResults == 3) return 10;
        if(maxResults == 2) return 5;

        return 0;
    }
}
