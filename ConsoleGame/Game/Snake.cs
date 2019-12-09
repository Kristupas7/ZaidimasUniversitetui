using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Game
{
    class Snake
    {
        const char SNAKE_CHAR = '@';
        const ConsoleColor SNAKE_COLOUR = ConsoleColor.Green;
        public int HeadX { get; set; } = 7;
        public int HeadY { get; set; } = 10;
        public List<int> Xs { get; set; } = new List<int>() {6 ,5, 4, 3};
        public List<int> Ys { get; set; } = new List<int>() {10, 10, 10, 10 };
        public int XDir { get; set; } = 1;
        public int YDir { get; set; } = 0;
        public Snake()
        {

        }
        public void Render(int xToRemove, int yToRemove, int xToAdd, int yToAdd)
        {
            Console.ForegroundColor = SNAKE_COLOUR;
            Console.SetCursorPosition(xToAdd, yToAdd);
            Console.Write(SNAKE_CHAR);
            Console.SetCursorPosition(xToRemove, yToRemove);
            Console.Write(" ");
        }
        public void Render(int xToAdd, int yToAdd)
        {
            Console.ForegroundColor = SNAKE_COLOUR;
            Console.SetCursorPosition(xToAdd, yToAdd);
            Console.Write(SNAKE_CHAR);
            
        }
        public void Grow(Fruit fruit)
        {
            Ys.Insert(0,fruit.Y);
            Xs.Insert(0,fruit.X);
            Render(fruit.X, fruit.Y);
        }
        public void Update()
        {
            int tempX = HeadX;
            int tempY = HeadY;

            HeadX = HeadX + XDir;
            HeadY = HeadY + YDir;

            Xs.Insert(0,tempX);
            Ys.Insert(0,tempY);

            Render(Xs[Xs.Count - 1], Ys[Ys.Count - 1], HeadX, HeadY);
            Xs.RemoveAt(Xs.Count - 1);
            Ys.RemoveAt(Ys.Count - 1);
        }
        

    }
}
