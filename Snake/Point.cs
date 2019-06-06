using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sym { get; set; }

        public Point()
        {
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Sym = point.Sym;
        }

        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Sym = sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    X -= offset;
                    break;
                case Direction.RIGHT:
                    X += offset;
                    break;
                case Direction.UP:
                    Y -= offset;
                    break;
                case Direction.DOWN:
                    Y += offset;
                    break;
                default:
                    break;
            }
        }

        public void Clear()
        {
            Sym = ' ';
            Draw();
        }

        public bool IsEquals(Point p)
        {
            return p.X == this.X && p.Y == this.Y;
        }


    }
}
