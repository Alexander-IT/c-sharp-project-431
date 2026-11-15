namespace App.Games;

class CalcGame : Game
{
    private const int MAX_RAND_FOR_MULT = 46340; // ~ root of Int32.MaxValue
    private const int MAX_RAND_FOR_ADD_AND_SUB = 1073741823; // ~ half of Int32.MaxValue
    private Random _randomGenerator = new();

    public override void GenerateNextQuestion(out string question, out string answer)
    {
        var typeOfOperator = _randomGenerator.Next(0, 3); // 0 - addition, 1 - subtraction, 2 - multiplication

        switch (typeOfOperator)
        {
            case 0:
                var addA = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var addB = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                question = $"{addA} + {addB}";
                answer = (addA + addB).ToString();
                break;
            case 1:
                var min = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                var sub = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
                question = $"{min} - {sub}";
                answer = (min - sub).ToString();
                break;
            case 2:
                var multA = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                var multB = _randomGenerator.Next(MAX_RAND_FOR_MULT);
                question = $"{multA} * {multB}";
                answer = (multA * multB).ToString();
                break;
            default:
                throw new InvalidOperationException(
                    "Can'not choose an operator for a question in a game. Random value: "
                        + typeOfOperator
                );
        }
    }

    public override string RULES_OF_THE_GAME => "What is the result of the expression?";
}
