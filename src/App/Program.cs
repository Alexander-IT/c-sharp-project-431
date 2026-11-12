static class Program
{
    public static void Main()
    {
        OpenMainMenu();

        switch (GetUserChoice())
        {
            case 0:
                break;
            case 1:
                Cli.Greeting();
                Cli.RequestUserName();
                break;
            case 2:
                Cli.Greeting();
                Cli.RequestUserName();
                ResultGameHandler.PrintResultGame(EvenGame.StartGame(), Cli.UserName);
                break;
        }
    }

    private static void OpenMainMenu()
    {
        Console.WriteLine(
            @"Please enter the game number and press Enter.
1 - Greet
2 - Even
0 - Exit"
        );
    }

    private static int GetUserChoice()
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
                return (int)userChoice;
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
}
