namespace App.Games;

class EvenGame : IGame
{
    private Random _randomGenerator = new();

    public void GenerateNextQuestion()
    {
        var question = _randomGenerator.Next();
        Question = question.ToString();
        Answer = question % 2 == 0 ? "yes" : "no";
    }

    public string Question{get; private set;} = string.Empty;

    public string Answer
    {
        get; private set;
    } = string.Empty;

    public string RULES_OF_THE_GAME => "Answer 'yes' if the number is even, otherwice answer 'no'.";
}
