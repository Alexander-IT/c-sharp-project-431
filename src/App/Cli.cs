namespace App;

static class Cli
{
    public static void Greeting() => Console.WriteLine("Welcome to the Brain Games!");

    public static string RequestUserName()
    {
        Console.Write("May I have your name? ");

        string userName;

        while (true)
        {
            userName = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Incorrect input. Please, enter a name again: ");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"Hello, {userName}!");
        return userName;
    }
}
