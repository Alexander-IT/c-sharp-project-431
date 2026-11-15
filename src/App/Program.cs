using App;

UIHandler.ShowMainMenu();
var menuPoint = UIHandler.GetUserChoice();

switch (menuPoint)
{
    case "Exit":
        return;
    case "Greet":
        Cli.Greeting();
        Cli.RequestUserName();
        break;
    default:
        Cli.Greeting();
        DataBase.AddValue("UserName", Cli.RequestUserName());
        Engine.StartGame(menuPoint, 3);
        break;
}
