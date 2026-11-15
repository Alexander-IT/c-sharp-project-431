namespace App.Games;

class PrimeGame : Game
{
    private Random _randomGenerator = new();
    private const int MAX_RAND_NUMBER = 1000; // If we use number bigger than 1000, we will rarely get prime number

    public override void GenerateNextQuestion(out string question, out string answer)
    {
        var randomNumber = _randomGenerator.Next(MAX_RAND_NUMBER);
        question = randomNumber.ToString();
        answer = isPrime(randomNumber) ? "yes" : "no";
    }

    private bool isPrime(int number)
    {
        for (var i = 2; i <= (int)Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    public override string RULES_OF_THE_GAME =>
        "Answer 'yes' if given number is prime. Otherwise answer 'no'.";
}
