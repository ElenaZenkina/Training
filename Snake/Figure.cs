using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (var point in pList)
            {
                point.Draw();
            }
        }

        public bool IsTravers(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsTravers(p)) return true;
            }
            return false;
        }

        public bool IsTravers(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsEquals(point)) return true;
            }
            return false;
        }

    }


}
