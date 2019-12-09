using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Gui;

namespace ConsoleGame.View
{
    class GuiController
    {
        private CreditWindow creditWindow;
        private GameWindow gameWindow;
        private GameController gameController;
        public GuiController()
        {
            creditWindow = new CreditWindow();
            gameWindow = new GameWindow();
            gameController = new GameController();
        }
        public void ShowMenu()
        {
            gameWindow.Render();
            bool needToRender = true;

            do
            {

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode)
                    {
                        case 27: //ConsoleKey.Escape:
                            needToRender = false;
                            Console.Clear();
                            break;
                        case 39: // ConsoleKey.RightArrow:
                            gameWindow.SwitchActiveButtonsToRight();
                            gameWindow.Render();
                            break;
                        case 37: // ConsoleKey.LeftArrow:
                            gameWindow.SwitchActiveButtonsToLeft();
                            gameWindow.Render();
                            break;
                        case 13:
                            switch (gameWindow.ActiveButtonIndex())
                            {
                                case 0:
                                    gameController.StartGame(this, new Game.GameScreen(50,30));
                                    break;
                                case 1:
                                    ShowCredits();
                                    needToRender = false;
                                    break;
                                case 2:
                                    Console.Clear();
                                    Environment.Exit(0);
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                }

                System.Threading.Thread.Sleep(250);
            } while (needToRender);
            
        }
        public void ShowCredits()
        {
            creditWindow.Render();
            bool needToRender = true;

            do
            {

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode)
                    {
                        case 27: //ConsoleKey.Escape:
                            needToRender = false;
                            Console.Clear();
                            break;
                        case 13:
                            Console.Clear();
                            ShowMenu();
                            needToRender = false;
                            break;
                    }
                }

                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}
