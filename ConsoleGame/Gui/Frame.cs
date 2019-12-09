using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Gui
{
    class Frame : GuiObject
    {
        private char renderChar;

        public Frame(int x, int y, int width, int height, char renderChar) : base(x, y, width, height)
        {
            this.renderChar = renderChar;
        }


        public override void Render()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(renderChar);
                    }
                }
                else
                {
                    Console.Write(renderChar);
                    for (int j = 0; j < width - 2; j++)
                    {
                        Console.Write(' ');
                    }

                    Console.Write(renderChar);
                }
            }
        }
    }

}
