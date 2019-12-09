using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleGame.View
{
    sealed class GameOverWindow : Window
    {
        private List<Button> buttons = new List<Button>();

        private TextBlock creditTextBlock;

        public GameOverWindow(int score) : base(28, 10, 60, 18, '@')
        {
            List<String> gameOverData = new List<string>();
            if (CheckIfHighScore(score))
            {
                gameOverData.Add("");
                gameOverData.Add("Game Over");
                gameOverData.Add("");
                gameOverData.Add($"Your score: {score}");
                gameOverData.Add("NEW HIGHSCORE");
                SaveScore(score);
            }
            else
            {
                gameOverData.Add("");
                gameOverData.Add("Game Over");
                gameOverData.Add("");
                gameOverData.Add($"Your score: {score}");
                SaveScore(score);
            }



            creditTextBlock = new TextBlock(28 + 1, 10 + 1, 60 - 1, gameOverData);


            buttons.Add(new Button(28 + 10, 10 + 14, 18, 3, "Play again"));
            buttons.Add(new Button(28 + 30, 10 + 14, 18, 3, "Main menu"));
            buttons[0].SetActive();
        }
        public override void Render()
        {
            base.Render();
            creditTextBlock.Render();
            foreach (Button button in buttons)
            {
                button.Render();
            }

            Console.SetCursorPosition(0, 0);
        }
        public void SaveScore(int score)
        {
            using (StreamWriter writetext = new StreamWriter("score.txt"))
            {
                writetext.WriteLine(score);
            }
        }
        public bool CheckIfHighScore(int score)
        {
            List<int> scores = new List<int>();
            using (StreamReader readtext = new StreamReader("score.txt"))
            {
                
                while (!readtext.EndOfStream)
                {
                    scores.Add(Convert.ToInt32(readtext.ReadLine()));
                }
                
            }
            for (int i = 0; i < scores.Count; i++)
            {
                if (score < scores[i])
                {
                    return false;
                }
            }
            return true;
        }
        public int ActiveButtonIndex()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsActive())
                {
                    return i;
                }
            }
            return 2;
        }
        public void SwitchActiveButtonsToRight()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsActive())
                {
                    if (i + 1 != buttons.Count)
                    {
                        buttons[i].SetInactive();
                        buttons[i + 1].SetActive();
                        break;
                    }
                }
            }
        }
        public void SwitchActiveButtonsToLeft()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsActive())
                {
                    if (i != 0)
                    {
                        buttons[i].SetInactive();
                        buttons[i - 1].SetActive();
                        break;
                    }
                }
            }
        }
    }
}
