using App;
using App.Games;
using Microsoft.VisualBasic;

Dictionary<string, Game> games = new(){
        { "Even", new EvenGame() },
        { "Calc", new CalcGame() },
        { "GCD", new GCDGame() },
        { "Progression", new ProgressionGame() },
        { "Prime", new PrimeGame() },
    };

UIHandler.ShowMainMenu(games.Keys.ToArray());



var menuPoint = UIHandler.GetUserChoice();
var gameRound = 3;

switch (menuPoint)
{
    case "Exit":
        return;
    case "Greet":
        GreetAndRequestName();
        break;
    default:
        games.TryGetValue(menuPoint, out Game? game);
        if(game == null)
            throw new ArgumentException($"This menu point does'nt exists: {menuPoint}");
        var questionsAnswers = game.GenerateQuestions(gameRound);
        var playerName = GreetAndRequestName();
        var playerWin = Engine.StartGame(
            questionsAnswers,
            game.RULES_OF_THE_GAME
        );
        UIHandler.PrintResultGame(playerWin, playerName);
        break;
}

string GreetAndRequestName()
{
    Cli.Greeting();
    return Cli.RequestUserName();
}

