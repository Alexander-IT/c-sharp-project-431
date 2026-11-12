public static class EvenGame
{
    private static Random _randomGenerator = new();

    public static bool StartGame() // Return true if user won, false if user lost
    {
        Console.WriteLine("Answer 'yes' if the number is even, otherwice answer 'no'.");

        for (var count = 0; count < 3; count++)
        {
            var randomNumber = _randomGenerator.Next();
            var expectedInput = randomNumber % 2 == 0 ? "yes" : "no";

            Console.WriteLine("Question: " + randomNumber);

            var userInput = Console.ReadLine();

            if (userInput?.ToLowerInvariant() == expectedInput)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine(
                    $"'yes' is wrong answer ;(. Correct answer was '{expectedInput}'."
                );
                return false;
            }
        }

        return true;
    }
}
