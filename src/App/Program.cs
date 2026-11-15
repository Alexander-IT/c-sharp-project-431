using App;

UIHandler.ShowMainMenu();
var menuPoint = UIHandler.GetUserChoice();

switch (menuPoint)
{
    case "Exit":
        return;
    case "Greet":
        Cli.RequestUserName();
        break;
    default:
        DataBase.AddValue("UserName", Cli.RequestUserName());
        Engine.StartGame(menuPoint, 3);
        break;
}
