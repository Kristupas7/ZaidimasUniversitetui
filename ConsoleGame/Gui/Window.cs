using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Gui
{
    class Window : GuiObject
    {

        private Frame border;

        public Window(int x, int y, int width, int height, char borderChar) : base(x, y, width, height)
        {
            base.x = x;
            base.y = y;
            base.width = width;
            base.height = height;

            border = new Frame(x, y, width, height, borderChar);
        }

        public override void Render()
        {
            border.Render();
        }
    }
}
