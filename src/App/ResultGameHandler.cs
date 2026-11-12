public static class ResultGameHandler
{
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
}
