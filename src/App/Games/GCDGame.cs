namespace App.Games;

class GCDGame : Game
{
    private Random _randomGenerator = new();

    public override void GenerateNextQuestion(out string question, out string answer)
    {
        var a = _randomGenerator.Next();
        var b = _randomGenerator.Next();

        question = $"{a} {b}";

        int commonDivisor = CalculateCommonDivisor(a, b);

        answer = commonDivisor.ToString();
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

    public override string RULES_OF_THE_GAME =>
        "Find the greatest common divisor of given numbers.";
}
