namespace App.Games;

class GCD : IGame
{
    private Random _randomGenerator = new();
    private string _question = string.Empty;
    private string _answer = string.Empty;

    public override void GenerateNextQuestion()
    {
        var a = _randomGenerator.Next();
        var b = _randomGenerator.Next();

        _question = $"{a} {b}";

        int commonDivisor = CalculateCommonDivisor(a, b);

        _answer = commonDivisor.ToString();
    }

    private int CalculateCommonDivisor(int a, int b)
    {
        int commonDivisor;

        if (b == 0)
            commonDivisor = a;

        while (b != 0)
        {
            var tmp = a % b;
            a = b;
            b = tmp;
        }
        commonDivisor = a;

        return commonDivisor;
    }

    public override string Question => _question;

    public override string Answer => _answer;

    public override string RULES_OF_THE_GAME => "Find the greatest common divisor of given numbers.";
}
