public class SessionController
{
    private const string sessionFile = "progress/GameSessions.csv";
    Func<int> GetSessionsQuantity = () => File.ReadAllLines(sessionFile).Count();


    public async Task<List<GameSession>> GetGameSessions()
    {

        if (!File.Exists(sessionFile)) throw new FileNotFoundException("Session File not exists!");

        string[] sessions = await File.ReadAllLinesAsync(sessionFile);
        List<GameSession> parsedSessions = new List<GameSession>();

        foreach (string session in sessions) parsedSessions.Add(ParseSession(session));

        return parsedSessions;
    }


    public GameSession CreateGameSession(string playerName)
    {

        if (playerName == "") throw new NullReferenceException("Error! Name is not empty");

        GameSession newGameSession = new GameSession(GetSessionsQuantity() + 1, playerName, 0);
        string[] gameSession = [SessionToString(newGameSession)];

        File.AppendAllLines(sessionFile, gameSession);

        return newGameSession;
    }

    public async Task SortInRanked(GameSession newGameSession){ 

        List<GameSession> gameSessions = await GetGameSessions();
        List<GameSession> filteredGameSession = gameSessions.Where((session) => session.Name != newGameSession.Name).ToList();

        filteredGameSession.Add(newGameSession);
        var sortedSessions = filteredGameSession.OrderByDescending((session) => session.Points);
        await File.WriteAllLinesAsync(sessionFile, sortedSessions.Select((session) => SessionToString(session)));
    }


    private GameSession ParseSession(string session)
    {
        string[] row = session.Split(",");
        GameSession parsedPlayer = new GameSession(int.Parse(row[0]), row[1], int.Parse(row[2]));

        return parsedPlayer;
    }

    private Func<GameSession, string> SessionToString = (gameSession) => $"{gameSession.Id},{gameSession.Name},{gameSession.Points}";

}