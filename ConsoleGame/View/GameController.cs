using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ConsoleGame.Game;

namespace ConsoleGame.View
{
    class GameController
    {
        public GameController()
        {
            GameScreen defaultGame = new GameScreen(50, 30);
        }
        public void StartGame(GuiController guiController, GameScreen myGame)
        {
            Console.Clear();
            ConsoleKeyInfo keyInfo;
            myGame.RenderFrames();
            while (!myGame.IsGameOver())
            {

                Thread.Sleep(Convert.ToInt16(100 / myGame.Speed));
                if (Console.KeyAvailable == true)
                {
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            myGame.SetDir(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            myGame.SetDir(0, 1);
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.SetDir(1, 0);
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.SetDir(-1, 0);
                            break;
                        case ConsoleKey.Escape:
                            PauseGame(guiController, myGame);
                            break;
                    }
                }
                myGame.Eat();
                myGame.Render();
            }
            EndGame(myGame.GetScore(), guiController);
        }
        public void EndGame(int score, GuiController guiController)
        {
            GameOverWindow gameOverWindow = new GameOverWindow(score);
            gameOverWindow.Render();
            bool needToRender = true;

            do
            {

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode)
                    {
                        case 39: // ConsoleKey.RightArrow:
                            gameOverWindow.SwitchActiveButtonsToRight();
                            gameOverWindow.Render();
                            break;
                        case 37: // ConsoleKey.LeftArrow:
                            gameOverWindow.SwitchActiveButtonsToLeft();
                            gameOverWindow.Render();
                            break;
                        case 13:
                            switch (gameOverWindow.ActiveButtonIndex())
                            {
                                case 0:
                                    StartGame(guiController, new GameScreen(50,30));
                                    break;
                                case 1:
                                    guiController.ShowMenu();
                                    needToRender = false;
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
        public void PauseGame(GuiController guiController,GameScreen myGame)
        {
            PauseWindow pauseWindow = new PauseWindow(myGame.GetScore());
            pauseWindow.Render();
            bool needToRender = true;

            do
            {

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode)
                    {
                        case 39: // ConsoleKey.RightArrow:
                            pauseWindow.SwitchActiveButtonsToRight();
                            pauseWindow.Render();
                            break;
                        case 37: // ConsoleKey.LeftArrow:
                            pauseWindow.SwitchActiveButtonsToLeft();
                            pauseWindow.Render();
                            break;
                        case 13:
                            switch (pauseWindow.ActiveButtonIndex())
                            {
                                case 0:
                                    StartGame(guiController, myGame);
                                    break;
                                case 1:
                                    guiController.ShowMenu();
                                    needToRender = false;
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
    }
}

