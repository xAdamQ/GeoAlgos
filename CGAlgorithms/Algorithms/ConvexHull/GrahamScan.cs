using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class GrahamScan : PointBasedAlgo
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
            ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            base.Run(points, lines, polygons, ref outPoints, ref outLines, ref outPolygons);

            points.Sort();
            RemoveExactPoints(ref points);

            var basePoint = points.OrderBy(p => p.Y).First();

            #region sort points based on thier angle with the start line

            var line = new Line(basePoint, new Point(basePoint.X + 9999, basePoint.Y));

            var list = new List<(double angle, Point point)>();
            foreach (var point in points)
            {
                if (point == basePoint) continue;

                var angle = new Line(line.End - line.Start).AngleWith(point - line.Start);

                if (angle < 0) angle += 360;

                list.Add((angle, point));
            }

            list.Sort();

            #endregion

            var stack = new Stack<Point>();
            stack.Push(basePoint);

            if (list.Count > 0) stack.Push(list[0].point);

            for (var i = 1; i < points.Count - 1; i++)
            {
                if (stack.Count < 2)
                    break;

                var first = stack.Pop();
                var second = stack.Peek();

                stack.Push(first);

                line = new Line(second, first);
                if (HelperMethods.CheckTurn(line, list[i].point) == Enums.TurnType.Left)
                {
                    stack.Push(list[i].point);
                }
                else if (HelperMethods.CheckTurn(line, list[i].point) == Enums.TurnType.Colinear)
                {
                    stack.Pop();
                    stack.Push(list[i].point);
                }
                else //right
                {
                    stack.Pop();
                    i--;
                }
            }

            outPoints.AddRange(stack);
        }

        public override string ToString()
        {
            return "Convex Hull - Graham Scan";
        }
    }
}