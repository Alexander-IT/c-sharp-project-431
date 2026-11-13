namespace App.Games;

abstract class IGame
{
    public abstract void GenerateNextQuestion();

    public abstract string Question { get; }

    public abstract string Answer { get; }

    public abstract string RULES_OF_THE_GAME { get; }
}
