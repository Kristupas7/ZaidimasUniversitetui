using ConsoleGame.Gui;
using System;
using System.Linq;

namespace ConsoleGame.Game
{
    internal class GameScreen : Window
    {
        private const double SpeedIncrement = 0.05;

        public double Speed { get; private set; } = 0.7;
        private readonly Snake snake = new Snake();
        private readonly Fruit fruit = new Fruit();
        private readonly Window scoreWindow = new Window(51, 0, 40, 10, '%');

        public GameScreen(int width, int height) : base(0, 0, width, height, '%')
        {
            this.width = width;
            this.height = height;
        }

        public void Eat()
        {
            if (snake.HeadX != fruit.X || snake.HeadY != fruit.Y) return;
            Speed += SpeedIncrement;
            snake.Grow(fruit);
            fruit.PlaceNewFruit();
            snake.Render(snake.HeadX, snake.HeadY);
            fruit.Render();
            RenderScore();
        }

        public void SetDir(int i, int j)
        {
            if (snake.XDir == -i || snake.YDir == -j) return;
            snake.XDir = i;
            snake.YDir = j;
        }
        public bool IsGameOver()
        {
            if (snake.HeadX > 48 || snake.HeadX < 1 || snake.HeadY > 28 || snake.HeadY < 1)
            {
                return true;
            }

            return snake.Xs.Where((t, i) => snake.HeadX == t && snake.HeadY == snake.Ys[i]).Any();
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
