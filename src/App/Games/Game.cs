namespace App.Games;

abstract class Game
{
    public abstract void GenerateNextQuestion(out string question, out string answer);

    public abstract string RULES_OF_THE_GAME { get; }
}
