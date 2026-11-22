namespace App;

static class Engine
{
    public static bool StartGame(Dictionary<string, string> questionsAnswers, string rulesOfGame, PrintGameInformation printInformation)
    {
        printInformation(rulesOfGame);

        foreach (var questionAnswer in questionsAnswers)
        {
            printInformation($"Question: {questionAnswer.Key}\nYour answer: ");
            var userAnswer = UIHandler.GetInputFromUser();

            if (questionAnswer.Value.Equals(userAnswer))
            {
                printInformation("Correct!");
            }
            else
            {
                printInformation(
                    $"'{userAnswer}' is wrong answer ;(. Correct answer was '{questionAnswer.Value}'."
                );
                return false;
            }
        }
        return true;
    }

    public delegate void PrintGameInformation(string printingText);
}
