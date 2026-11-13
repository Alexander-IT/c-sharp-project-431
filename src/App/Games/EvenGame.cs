namespace App.Games;

class EvenGame : IGame
{
    private Random _randomGenerator = new();
    private string _question = string.Empty;
    private string _answer = string.Empty;

    public override void GenerateNextQuestion()
    {
        var question = _randomGenerator.Next();
        _question = question.ToString();
        _answer = question % 2 == 0 ? "yes" : "no";
    }

    public override string Question => _question;

    public override string Answer => _answer;

    public override string RULES_OF_THE_GAME =>
        "Answer 'yes' if the number is even, otherwise answer 'no'.";
}
