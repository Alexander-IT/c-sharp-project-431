namespace App.Games;

class GCD : IGame
{
    private Random _randomGenerator = new();

    public void GenerateNextQuestion()
    {
        var a = _randomGenerator.Next();
        var b = _randomGenerator.Next();

        Question = $"{a} {b}";

        int commonDivisor;

        if (b == 0)
            commonDivisor = a;
        else
        {
            while (b != 0)
            {
                var tmp = a % b;
                a = b;
                b = tmp;
            }
            commonDivisor = a;
        }

        Answer = commonDivisor.ToString();
    }

    public string Question { get; private set; } = string.Empty;

    public string Answer { get; private set; } = string.Empty;

    public string RULES_OF_THE_GAME => "What is the result of the expression?";
}
