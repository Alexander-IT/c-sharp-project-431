using App.Games;

namespace App;

static class Engine
{
    public static bool StartGame(
        Dictionary<string, string> questionsAnswers,
        string rulesOfGame
    )
    {
        UIHandler.PrintInformation(rulesOfGame);

        foreach (var questionAnswer in questionsAnswers)
        {
            UIHandler.PrintInformation($"Question: {questionAnswer.Key}\nYour answer: ");
            var userAnswer = UIHandler.GetInputFromUser();

            if (questionAnswer.Value.Equals(userAnswer))
            {
                UIHandler.PrintInformation("Correct!");
            }
            else
            {
                UIHandler.PrintInformation(
                    $"'{userAnswer}' is wrong answer ;(. Correct answer was '{questionAnswer.Value}'."
                );
                return false;
            }
        }
        return true;
    }
}
