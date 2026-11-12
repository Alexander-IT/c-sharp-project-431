namespace App.Games;

interface IGame
{
    public void GenerateNextQuestion();

    public string Question { get; }

    public string Answer { get; }

    string RULES_OF_THE_GAME { get; }
}
