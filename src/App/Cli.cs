static class Cli
{
    private static string _userName = string.Empty;

    public static string UserName
    {
        get => _userName;
    }

    public static void Greeting() => Console.WriteLine("Welcome to the Brain Games!");

    public static void RequestUserName()
    {
        Console.Write("May I have your name? ");

        while (true)
        {
            _userName = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(_userName))
            {
                Console.WriteLine("Incorrect input. Please, enter a name again: ");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"Hello, {_userName}!");
    }
}
