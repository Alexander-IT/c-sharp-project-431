namespace App.Games;

class CalcGame : IGame
{
    private const int MAX_RAND_FOR_MULT = 46340; // ~ root of Int32.MaxValue
    private const int MAX_RAND_FOR_ADD_AND_SUB = 1073741823; // ~ half of Int32.MaxValue
    private Random _randomGenerator = new();

    public void GenerateNextQuestion()
    {
        var typeOfOperator = _randomGenerator.Next(0, 3); // 0 - addition, 1 - subtraction, 2 - multiplication

        switch (typeOfOperator)
        {
            case 0:
                var addA = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var addB = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                Question = $"{addA} + {addB}";
                Answer = (addA + addB).ToString();
                break;
            case 1:
                var min = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var sub = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                Question = $"{min} - {sub}";
                Answer = (min - sub).ToString();
                break;
            case 2:
                var multA = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                var multB = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                Question = $"{multA} * {multB}";
                Answer = (multA * multB).ToString();
                break;
        }
    }

    public string Question { get; private set; } = string.Empty;

    public string Answer { get; private set; } = string.Empty;

    public string RULES_OF_THE_GAME => "What is the result of the expression?";
}
