using System;
using System.Collections.Generic;

namespace ConsoleGame.Game
{
    internal class Snake
    {
        private const char SnakeChar = '@';
        private const ConsoleColor SnakeColor = ConsoleColor.Green;
        public int HeadX { get; set; } = 7;
        public int HeadY { get; set; } = 10;
        public List<int> Xs { get; set; } = new List<int>() {6 ,5, 4, 3};
        public List<int> Ys { get; set; } = new List<int>() {10, 10, 10, 10 };
        public int XDir { get; set; } = 1;
        public int YDir { get; set; } = 0;

        public void Render(int xToRemove, int yToRemove, int xToAdd, int yToAdd)
        {
            Console.ForegroundColor = SnakeColor;
            Console.SetCursorPosition(xToAdd, yToAdd);
            Console.Write(SnakeChar);
            Console.SetCursorPosition(xToRemove, yToRemove);
            Console.Write(" ");
        }
        public void Render(int xToAdd, int yToAdd)
        {
            Console.ForegroundColor = SnakeColor;
            Console.SetCursorPosition(xToAdd, yToAdd);
            Console.Write(SnakeChar);
            
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
