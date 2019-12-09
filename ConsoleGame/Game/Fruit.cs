using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Game
{
    class Fruit
    {
        const char FRUIT_CHAR = 'O';
        const ConsoleColor FRUIT_COLOUR = ConsoleColor.White;
        public int X { get; set; }
        public int Y { get; set; }
        public Fruit()
        {
            PlaceNewFruit();
        }
        public void PlaceNewFruit()
        {
            Random position = new Random();
            X = position.Next(1, 49);
            Y = position.Next(1, 29);
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = FRUIT_COLOUR;
            Console.Write(FRUIT_CHAR);
        }
    }
}
