using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms
{
    public abstract class PointBasedAlgo : Algorithm
    {
        protected void RemoveExactPoints(ref List<Point> points)
        {
            //var i = 1;
            //while (i < points.Count)
            //    if (points[i].Equals(points[i - 1]))
            //        points.RemoveAt(i);
            //    else i++;

            points = points.GroupBy(p => (p.X, p.Y)).Select(g => g.First()).ToList();
        }

        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
            ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            if (points.Count == 0)
                throw new BadAlgoInputException("there is no points to act on!");
        }
    }
}