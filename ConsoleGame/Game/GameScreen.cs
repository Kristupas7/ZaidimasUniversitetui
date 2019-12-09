using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Game
{
    class GameScreen : Window
    {
        const double SPEED_INCREMENT = 0.05;
        private int width;
        private int height;
        public double Speed { get; private set; } = 0.7;
        private Snake snake = new Snake();
        private Fruit fruit = new Fruit();
        private Window scoreWindow = new Window(51, 0, 40, 10, '%');

        public GameScreen(int width, int height) : base(0, 0, width, height, '%')
        {
            this.width = width;
            this.height = height;
        }

        public void Eat()
        {
            if (snake.HeadX == fruit.X && snake.HeadY == fruit.Y)
            {
                Speed = Speed + SPEED_INCREMENT;
                snake.Grow(fruit);
                fruit.PlaceNewFruit();
                snake.Render(snake.HeadX, snake.HeadY);
                fruit.Render();
                RenderScore();
            }
        }

        public void SetDir(int x, int y)
        {
            if (snake.XDir != -x && snake.YDir != -y)
            {
                snake.XDir = x;
                snake.YDir = y;
            }
        }
        public bool IsGameOver()
        {
            if (snake.HeadX > 48 || snake.HeadX < 1 || snake.HeadY > 28 || snake.HeadY < 1)
            {
                return true;
            }
            for (int i = 0; i < snake.Xs.Count; i++)
            {
                if (snake.HeadX == snake.Xs[i] && snake.HeadY == snake.Ys[i])
                {
                    return true;
                }
            }
            return false;
        }
        public override void Render()
        {
            snake.Update();
            fruit.Render();
        }
        public void RenderScore()
        {
            Console.SetCursorPosition(53, 3);
            Console.WriteLine("Press escape to pause");
            Console.SetCursorPosition(53, 6);
            Console.WriteLine($"Score: {snake.Xs.Count - 4}");
        }
        public int GetScore()
        {
            return (snake.Xs.Count - 4);
        }
        public void RenderFrames()
        {
            base.Render();
            scoreWindow.Render();
            RenderScore();
            fruit.Render();
        }
    }
}
