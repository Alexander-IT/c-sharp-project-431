namespace App.Games;

class Prime : IGame
{
    private Random _randomGenerator = new();
    private string _question = string.Empty;
    private string _answer = string.Empty;
    private const int MAX_RAND_NUMBER = 1000; // If we use number bigger than 1000, we will rarely get prime number


    public override void GenerateNextQuestion()
    {
        var question = _randomGenerator.Next(MAX_RAND_NUMBER);
        _question = question.ToString();
        _answer = isPrime(question) ? "yes" : "no";
    }

    private bool isPrime(int number)
    {
        for(var i = 2; i <= (int)Math.Sqrt(number); i++)
        {
            if(number % i == 0)
                return false;
        }

        return true;
    }

    public override string Question => _question;

    public override string Answer => _answer;

    public override string RULES_OF_THE_GAME => "Answer 'yes' if given number is prime. Otherwise answer 'no'.";
}