using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        const byte MAP_WIDTH = 80;
        const byte MAP_HEIGHT = 25;

        static void Main(string[] args)
        {
            Borders borders = new Borders(MAP_WIDTH, MAP_HEIGHT);
            borders.Draw();


            /*Console.SetBufferSize(MAP_WIDTH, MAP_HEIGHT);

            var upLine = new HorizontalLine(0, 78, 0, '+');
            var downLine = new HorizontalLine(0, 78, 24, '+');
            var leftLine = new VerticalLine(0, 0, 24, '+');
            var rightLine = new VerticalLine(78, 0, 24, '+');

            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();*/


            var point = new Point(3, 4, '*');
            var snake = new Snake(point, 4, Direction.RIGHT);
            snake.Draw();
            Point food = CreateFood(snake);


            while (true)
            {
                // Если змейка встретилась со своим хвостом или 
                // с границей экрана - конец игры
                if (borders.IsTravers(snake) || snake.IsTraversTail())
                    break;

                // Если змейка встретилась с едой
                if (snake.Eat(food))
                    food = CreateFood(snake);
                else snake.Move();

                // Нажатие клавиш для управления змейкой
                if (Console.KeyAvailable)
                    snake.HandleKey(Console.ReadKey().Key);

                // Задержка в 200 мс
                Thread.Sleep(200);
            }


            Console.ReadLine();

        }

        private static Point CreateFood(Figure snake)
        {
            Point food = FoodCreator.CreateFood(MAP_WIDTH, MAP_HEIGHT, '$');
            // Еда не должна создаться в теле змейки
            while (snake.IsTravers(food))
            {
                food = FoodCreator.CreateFood(MAP_WIDTH, MAP_HEIGHT, '$');
            }
            food.Draw();
            return food;
        }

    }
}
