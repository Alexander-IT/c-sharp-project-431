namespace App.Games;

class EvenGame : Game
{
    private Random _randomGenerator = new();

    public override void GenerateNextQuestion(out string question, out string answer)
    {
        var randomNumber = _randomGenerator.Next();
        question = randomNumber.ToString();
        answer = randomNumber % 2 == 0 ? "yes" : "no";
    }

    public override string RULES_OF_THE_GAME =>
        "Answer 'yes' if the number is even, otherwise answer 'no'.";
}
