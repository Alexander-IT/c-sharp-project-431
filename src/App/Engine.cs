using App.Games;

namespace App;

static class Engine
{
    public static void StartGame(TypesOfGames gameType, string userName)
    {
        // In last step of project I read, what I don't need use abstrac classes and interface
        // So I write how I can do this without it:
        // Create switch, every case will create different games and call their methods
        IGame game = GetGame(gameType); 

        Console.WriteLine(game.RULES_OF_THE_GAME);

        for (var count = 0; count < 3; count++)
        {
            game.GenerateNextQuestion();
            Console.WriteLine($"Question: {game.Question}\nYour answer: ");
            var userAnswer = Console.ReadLine()?.Trim();

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
            Console.WriteLine($"Congratulations, {userName}!");
        }
        else
        {
            Console.WriteLine($"Let's try again, {userName}!");
        }
    }

    private static IGame GetGame(TypesOfGames gameType) =>
        gameType switch
        {
            TypesOfGames.Even => new EvenGame(),
            TypesOfGames.Calc => new CalcGame(),
            TypesOfGames.GCD => new GCD(),
            TypesOfGames.Progression => new Progression(),
            TypesOfGames.Prime => new Prime(),
            _ => throw new ArgumentException(
                "Incorrect type of game, There is not in enum TypesOfGames"
            ),
        };

    public enum TypesOfGames
    {
        Even = 0,
        Calc = 1,
        GCD = 2,
        Progression = 3,
        Prime = 4,
    }
}
