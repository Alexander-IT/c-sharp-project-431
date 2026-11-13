namespace App.Games;

class CalcGame : IGame
{
    private const int MAX_RAND_FOR_MULT = 46340; // ~ root of Int32.MaxValue
    private const int MAX_RAND_FOR_ADD_AND_SUB = 1073741823; // ~ half of Int32.MaxValue
    private Random _randomGenerator = new();
    private string _question = string.Empty;
    private string _answer = string.Empty;

    public override void GenerateNextQuestion()
    {
        var typeOfOperator = _randomGenerator.Next(0, 3); // 0 - addition, 1 - subtraction, 2 - multiplication

        switch (typeOfOperator)
        {
            case 0:
                var addA = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var addB = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                _question = $"{addA} + {addB}";
                _answer = (addA + addB).ToString();
                break;
            case 1:
                var min = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var sub = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                _question = $"{min} - {sub}";
                _answer = (min - sub).ToString();
                break;
            case 2:
                var multA = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                var multB = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                _question = $"{multA} * {multB}";
                _answer = (multA * multB).ToString();
                break;
        }
    }

    public override string Question => _question;

    public override string Answer => _answer;

    public override string RULES_OF_THE_GAME => "What is the result of the expression?";
}
