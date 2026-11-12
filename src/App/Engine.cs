using App.Games;

namespace App;

static class Engine
{
    public static void StartGame(TypesOfGames gameType, string userName)
    {
        IGame game = GetGame(gameType);

        Console.WriteLine(game.RULES_OF_THE_GAME);

        for (var count = 0; count < 3; count++)
        {
            game.GenerateNextQuestion();
            Console.WriteLine($"Question: {game.Question}\nYour answer: ");
            var userAnswer = Console.ReadLine();

            if (game.Answer.Equals(userAnswer))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine(
                    $"'{userAnswer}' is wrong answer ;(. Correct answer was '{game.Answer}'."
                );
                PrintResultGame(false, userName);
                return;
            }
        }
        PrintResultGame(true, userName);
    }

    public static void PrintResultGame(bool didUserWin, string userName)
    {
        if (didUserWin)
        {
            Console.WriteLine($"Congragulations, {userName}!");
        }
        else
        {
            Console.WriteLine($"Let's try again, {userName}");
        }
    }

    private static IGame GetGame(TypesOfGames gameType) =>
        gameType switch
        {
            TypesOfGames.Even => new EvenGame(),
            TypesOfGames.Calc => new CalcGame(),
            TypesOfGames.GCD => new GCD(),
            _ => throw new ArgumentException(
                "Incorrect type of game, There is not in enum TypesOfGames"
            ),
        };

    public enum TypesOfGames
    {
        Even = 0,
        Calc = 1,
        GCD = 2,
    }
}
