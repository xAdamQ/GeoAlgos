using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremePoints : PointBasedAlgo
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
            ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            base.Run(points, lines, polygons, ref outPoints, ref outLines, ref outPolygons);

            RemoveExactPoints(ref points);

            foreach (var point in points)
                if (PointOut(point, points))
                    outPoints.Add(point);
        }

        bool PointOut(Point point, List<Point> points)
        {
            for (int j = 0; j < points.Count; j++)
            for (int k = 0; k < points.Count; k++)
            for (int l = 0; l < points.Count; l++)
            {
                if (point.Equals(points[j]) || point.Equals(points[k]) || point.Equals(points[l])) continue;
                //skip if the point is part of the triangle

                if (HelperMethods.PointInTriangle(point, points[j], points[k], points[l])
                    != Enums.PointInPolygon.Outside)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return "Convex Hull - Extreme Points";
        }
    }
}