using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Borders
    {
        private List<Figure> lineList;

        public Borders(int mapWidth, int mapHeight)
        {
            lineList = new List<Figure>();

            Console.SetBufferSize(mapWidth, mapHeight);

            // Создаем 4 линии по краям экрана
            /*Line line;
            line = new Line(new Point(0, 0, '+'), mapWidth - 2, Direction.RIGHT);
            lineList.Add(line);
            line = new Line(new Point(0, 0, '+'), mapHeight - 1, Direction.DOWN);
            lineList.Add(line);
            line = new Line(new Point(0, mapHeight - 1, '+'), mapWidth - 2, Direction.RIGHT);
            lineList.Add(line);
            line = new Line(new Point(mapWidth - 2, 0, '+'), mapHeight - 1, Direction.DOWN);
            lineList.Add(line);*/

            lineList.Add(new HorizontalLine(0, mapWidth - 2, 0, '+'));
            lineList.Add(new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+'));
            lineList.Add(new VerticalLine(0, 0, mapHeight - 1, '+'));
            lineList.Add(new VerticalLine(mapWidth - 2, 0, mapHeight - 1, '+'));


            /*var upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            var downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            var leftLine = new VerticalLine(0, 0, mapHeight - 1, '+');
            var rightLine = new VerticalLine(mapWidth - 2, 0, mapHeight - 1, '+');

            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();*/
        }

        public void Draw()
        {
            foreach (var line in lineList)
            {
                line.Draw();
            }
        }

        /// <summary>
        /// Пересекается ли рамка с фигурой
        /// </summary>
        /// <param name="figure"></param>
        /// <returns>Да/Нет</returns>
        public bool IsTravers(Figure figure)
        {
            // Для каждой линии в рамке
            foreach (var line in lineList)
            {
                // Пересекается ли линия с фигурой
                if (line.IsTravers( figure )) return true;
            }
            return false;
        }
    }
}
