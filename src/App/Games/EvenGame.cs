namespace App.Games;

class EvenGame : Game
{
    private Random _randomGenerator = new();

    public override Dictionary<string, string> GenerateQuestions(int quantityOfQuestions)
    {
        Dictionary<string, string> questionsAnswers = new();

        for (var i = 0; i < quantityOfQuestions; i++)
        {
            var randomNumber = _randomGenerator.Next();
            var question = randomNumber.ToString();

            // Check: if there is a same question in Dictionary - repeat this step
            if (questionsAnswers.ContainsKey(question))
            {
                i--;
                continue;
            }

            var answer = randomNumber % 2 == 0 ? "yes" : "no";
            questionsAnswers.Add(question, answer);
        }

        return questionsAnswers;
    }

    public override string GameRules =>
        "Answer 'yes' if the number is even, otherwise answer 'no'.";
}
