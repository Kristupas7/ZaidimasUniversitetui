using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.View
{
    sealed class CreditWindow : Window
    {

        private Button backButton;

        private TextBlock creditTextBlock;

        public CreditWindow() : base(28, 10, 60, 18, '@')
        {
            List<String> creditData = new List<string>();

            creditData.Add("");
            creditData.Add("Kristupas Žalionis");
            creditData.Add("");
            

            creditTextBlock = new TextBlock(28 + 1, 10 + 1, 60 - 1, creditData);


            backButton = new Button(28 + 20, 10 + 14, 18, 3, "Back");
            backButton.SetActive();
        }

        public override void Render()
        {
            base.Render();
            creditTextBlock.Render();
            backButton.Render();

            Console.SetCursorPosition(0, 0);
        }

    }
}
