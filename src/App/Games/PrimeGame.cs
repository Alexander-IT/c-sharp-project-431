namespace App.Games;

class PrimeGame : Game
{
    private Random _randomGenerator = new();
    private const int MAX_RAND_NUMBER = 1000; // If we use number bigger than 1000, we will rarely get prime number

    public override Dictionary<string, string> GenerateQuestions(int quantityOfQuestions)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantityOfQuestions; i++)
        {
            var randomNumber = _randomGenerator.Next(MAX_RAND_NUMBER);
            var question = randomNumber.ToString();

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            var answer = isPrime(randomNumber) ? "yes" : "no";
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
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

    public override string GameRules =>
        "Answer 'yes' if given number is prime. Otherwise answer 'no'.";
}
