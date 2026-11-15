using App.Games;

namespace App;

static class Engine
{
    private static readonly Dictionary<string, Game> _gameNamesAndGames = new Dictionary<
        string,
        Game
    >()
    {
        { "Even", new EvenGame() },
        { "Calc", new CalcGame() },
        { "GCD", new GCDGame() },
        { "Progression", new ProgressionGame() },
        { "Prime", new PrimeGame() },
    };

    private static readonly string[] _gameNames = _gameNamesAndGames.Keys.ToArray();

    public static void StartGame(String gameName, int roundCount)
    {
        // In last step of project I read, what I don't need use abstrac classes and interface
        // So I write how I can do this without it:
        // Create switch, every case will create different games and call their methods
        if (!_gameNamesAndGames.ContainsKey(gameName))
        {
            throw new ArgumentException("A game with this name doesn't exists: " + gameName);
        }

        Game game = _gameNamesAndGames.GetValueOrDefault(gameName);

        UIHandler.PrintInformation(game.RULES_OF_THE_GAME);

        for (var count = 0; count < roundCount; count++)
        {
            game.GenerateNextQuestion(out string question, out string answer);
            UIHandler.PrintInformation($"Question: {question}\nYour answer: ");
            var userAnswer = UIHandler.GetInputFromUser();

            if (answer.Equals(userAnswer))
            {
                UIHandler.PrintInformation("Correct!");
            }
            else
            {
                UIHandler.PrintInformation(
                    $"'{userAnswer}' is wrong answer ;(. Correct answer was '{answer}'."
                );
                UIHandler.PrintResultGame(false);
                return;
            }
        }
        UIHandler.PrintResultGame(true);
    }

    public static string[] GameNames => _gameNames;
}
