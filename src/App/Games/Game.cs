namespace App.Games;

abstract class Game
{
    public abstract Dictionary<string, string> GenerateQuestions(int quantityOfQuestions);

    public abstract string RULES_OF_THE_GAME { get; }
}
