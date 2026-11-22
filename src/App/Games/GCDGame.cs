using System.Runtime.InteropServices;

namespace App.Games;

class GCDGame : Game
{
    private Random _randomGenerator = new();

    public override Dictionary<string, string> GenerateQuestions(int quantityOfQuestions)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantityOfQuestions; i++)
        {
            var a = _randomGenerator.Next();
            var b = _randomGenerator.Next();

            var question = $"{a} {b}";

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            int commonDivisor = CalculateCommonDivisor(a, b);
            var answer = commonDivisor.ToString();
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
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

    public override string GameRules =>
        "Find the greatest common divisor of given numbers.";
}
