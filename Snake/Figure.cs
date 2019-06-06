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
    }
}
