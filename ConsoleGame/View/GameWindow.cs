using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.View
{
    sealed class GameWindow : Window
    {

        private TextBlock titleTextBlock;
        private List<Button> buttons = new List<Button>(); 

        public GameWindow() : base(0, 0, 120, 30, '%')
        {
            buttons.Add (new Button(20, 13, 18, 5, "Start"));
            buttons[0].SetActive();


            buttons.Add(new Button(50, 13, 18, 5, "Credits"));

            buttons.Add (new Button(80, 13, 18, 5, "Quit"));

            titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Snake v1.0", "Made by:", "Kristupas Zalionis" });
        }

        public override void Render()
        {
            base.Render();

            titleTextBlock.Render();

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Render();
            }

            Console.SetCursorPosition(0, 0);
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
             for(int i = 0; i < buttons.Count; i++)
             {
                 if (buttons[i].IsActive())
                 {
                     if (i + 1 != buttons.Count)
                     {
                         buttons[i].SetInactive();
                         buttons[i+1].SetActive();
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
