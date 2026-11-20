namespace App.Games;

class CalcGame : Game
{
    private const int MAX_RAND_FOR_MULT = 46340; // ~ root of Int32.MaxValue
    private const int MAX_RAND_FOR_ADD_AND_SUB = 1073741823; // ~ half of Int32.MaxValue
    private Random _randomGenerator = new();

    public override Dictionary<string, string> GenerateQuestions(int quantity)
    {
        var typeOfOperator = _randomGenerator.Next(0, 3); // 0 - addition, 1 - subtraction, 2 - multiplication

        switch (typeOfOperator)
        {
            case 0:
                return GenerateQuestionsForAddition(quantity);
            case 1:
                return GenerateQuestionsForSubtraction(quantity);
            case 2:
                return GenerateQuestionsForMultiplication(quantity);
            default:
                throw new InvalidOperationException(
                    "Can'not choose an operator for a question in a game. Random value: "
                        + typeOfOperator
                );
        }
    }

    private Dictionary<string, string> GenerateQuestionsForAddition(int quantity)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantity; i++)
        {
            var addA = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
            var addB = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
            var question = $"{addA} + {addB}";

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            var answer = (addA + addB).ToString();
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
    }

    private Dictionary<string, string> GenerateQuestionsForSubtraction(int quantity)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantity; i++)
        {
            var min = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
            var sub = _randomGenerator.Next(MAX_RAND_FOR_ADD_AND_SUB);
            var question = $"{min} - {sub}";

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            var answer = (min - sub).ToString();
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
    }

    private Dictionary<string, string> GenerateQuestionsForMultiplication(int quantity)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantity; i++)
        {
            var multA = _randomGenerator.Next(MAX_RAND_FOR_MULT);
            var multB = _randomGenerator.Next(MAX_RAND_FOR_MULT);
            var question = $"{multA} * {multB}";

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            var answer = (multA * multB).ToString();
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
    }

    public override string RULES_OF_THE_GAME => "What is the result of the expression?";
}
