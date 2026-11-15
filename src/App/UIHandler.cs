using System.Text;

namespace App;

public static class UIHandler
{
    private static readonly string[] menuPoints = ["Exit", "Greet", .. Engine.GameNames];

    public static void ShowMainMenu()
    {
        StringBuilder mainMenuText = new(
            $@"Please enter the game number and press Enter.
1 - {menuPoints[1]}"
        );

        for (var i = 2; i < menuPoints.Length; i++)
        {
            mainMenuText.Append($"\n{i} - {menuPoints[i]}");
        }

        mainMenuText.Append($"\n0 - {menuPoints[0]}");
        mainMenuText.Append("\nYour choice:");
        Console.WriteLine(mainMenuText.ToString());
    }

    public static string GetUserChoice()
    {
        int? userChoice;
        while (true)
        {
            var userInput = Console.ReadLine();

            try
            {
                userChoice = int.Parse(userInput ?? string.Empty);
            }
            catch (FormatException)
            {
                Console.Write("Inccorect input. Please, enter your choice again: ");
                continue;
            }

            // 2 + Engine.GameNames.Length - User can write number of Game or Exit/Greet
            if (userChoice >= 0 && userChoice < menuPoints.Length)
            {
                return menuPoints[(int)userChoice];
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

    public static void PrintResultGame(bool didUserWin)
    {
        if (didUserWin)
        {
            Console.WriteLine($"Congratulations, {DataBase.GetValue("UserName")}!");
        }
        else
        {
            Console.WriteLine($"Let's try again, {DataBase.GetValue("UserName")}!");
        }
    }

    public static void PrintInformation(string s) => Console.WriteLine(s);

    public static string? GetInputFromUser() => Console.ReadLine()?.Trim();
}
