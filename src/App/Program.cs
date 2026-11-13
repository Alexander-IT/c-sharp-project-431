namespace App;

static class Program
{
    public static void Main()
    {
        OpenMainMenu();
        var menuPoints = GetUserChoice();

        if (menuPoints == MenuPoints.Exit)
        {
            return;
        }
        else
        {
            Cli.Greeting();
            var userName = Cli.RequestUserName();

            if (menuPoints != MenuPoints.Greet)
            {
                // (menuPoints - 2) because we have an offset relative Engine.TypesOfGame
                Engine.StartGame((Engine.TypesOfGames)menuPoints - 2, userName);
            }
        }
    }

    private static void OpenMainMenu()
    {
        Console.WriteLine(
            @$"Please enter the game number and press Enter.
1 - {(MenuPoints)1}
2 - {(MenuPoints)2}
3 - {(MenuPoints)3}
4 - {(MenuPoints)4}
5 - {(MenuPoints)5}
6 - {(MenuPoints)6}
0 - {(MenuPoints)0}"
        );
    }

    private static MenuPoints GetUserChoice()
    {
        int? userChoice = null;

        while (true)
        {
            var userInput = Console.ReadLine();

            try
            {
                userChoice = int.Parse(userInput ?? string.Empty);
            }
            catch (FormatException)
            {
                Console.WriteLine("Inccorect input. Please, enter your choice again: ");
                continue;
            }

            if (userChoice >= 0 && userChoice <= 6)
            {
                return (MenuPoints)userChoice;
            }
            else
            {
                Console.WriteLine(
                    "A menu item with the entered number doesn't exist."
                        + "\nPlease, enter you choice again: "
                );
            }
        }
    }

    private enum MenuPoints
    {
        Exit = 0,
        Greet = 1,
        Even = 2,
        Calc = 3,
        GCD = 4,
        Progression = 5,
        Prime = 6
    }
}
