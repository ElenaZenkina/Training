using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();

            // Для каждой точки змейки, начиная от хвоста
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }

        }

        public void Move()
        {
            // Удаление хвоста змейки
            Point tail = pList.First();
            pList.Remove(tail);

            // Новая точка головы змейки
            Point head = GetHeadPoint();
            pList.Add(head);

            // На экране: удаляем точку хвоста, отображаем точку головы
            tail.Clear();
            head.Draw();
        }

        // Получить новую точку головы
        public Point GetHeadPoint()
        {
            Point p = pList.Last();
            Point head = new Point(p);
            head.Move(1, direction);
            return head;
        }

        public bool Eat(Point food)
        {
            // Новая точка головы змейки
            Point head = GetHeadPoint();

            // Встретилась ли голова змейки  с едой
            if (head.IsEquals(food))
            {
                food.Sym = head.Sym;
                food.Draw();
                pList.Add(food);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Изменение направления движения змейки
        /// </summary>
        /// <param name="key"></param>
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

        public bool IsTraversTail()
        {
            // Точка головы змейки
            Point head = pList.Last();

            // Для всех точек змейки, кроме головы
            for (int i = 0; i < pList.Count - 2; i++)
            {
                // Есть ли пересечение тела змейки с головой
                if (head.IsEquals(pList[i])) return true;
            }
            return false;
        }

    }
}
