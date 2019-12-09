using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Gui
{
    abstract class GuiObject
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        public GuiObject(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public abstract void Render();

    }
}
