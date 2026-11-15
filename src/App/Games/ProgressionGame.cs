using System.Text.RegularExpressions;

namespace App.Games;

class ProgressionGame : Game
{
    // Max steps of progression - 15, max value for one step - 1000
    private const int MAX_ONE_STEP = 1000;
    private const int MAX_LENGTH = 15;
    private const int MAX_START_PROGRESSION = Int32.MaxValue - MAX_ONE_STEP * MAX_LENGTH;
    private Random _randomGenerator = new();

    public override void GenerateNextQuestion(out string question, out string answer)
    {
        var start = _randomGenerator.Next(MAX_START_PROGRESSION);
        var step = _randomGenerator.Next(MAX_ONE_STEP);
        var length = _randomGenerator.Next(5, MAX_LENGTH + 1);

        var numbers = GenerateProgression(start, step, length);

        var hiddenNumber = numbers[_randomGenerator.Next(length)];

        // Call Trim(), because after replace string can has space in start or end
        question = Regex
            .Replace(string.Join(' ', numbers), $"(^| ){hiddenNumber}($| )", " .. ")
            .Trim();

        answer = hiddenNumber.ToString();
    }

    private int[] GenerateProgression(int start, int step, int length)
    {
        int[] numbers = new int[length];

        for (var i = 0; i < length; i++)
        {
            numbers[i] = start + step * i;
        }

        return numbers;
    }

    public override string RULES_OF_THE_GAME => "What number is missing in the progression?";
}
