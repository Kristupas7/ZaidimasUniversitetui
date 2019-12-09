using ConsoleGame.Game;
using ConsoleGame.View;
using System;

class MainApp
{
    static void Main()
    {
        Console.CursorVisible = false;
        GuiController guiController = new GuiController();
        guiController.ShowMenu();

    }
}