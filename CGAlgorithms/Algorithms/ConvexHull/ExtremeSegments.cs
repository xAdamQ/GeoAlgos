using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremeSegments : PointBasedAlgo
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
            ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            base.Run(points, lines, polygons, ref outPoints, ref outLines, ref outPolygons);

            if (points.Count < 3)
            {
                outPoints.AddRange(points);
                return;
            }

            var outPointsHS = new HashSet<Point>();

            RemoveExactPoints(ref points);
            //points = points.Distinct().ToList();

            for (int i = 0; i < points.Count; i++)
            for (int j = 0; j < points.Count; j++)
            {
                if (points[i] == points[j]) continue;
                //skip the same point

                var segment = new Line(points[i], points[j]);
                var leftCount = 0;
                var rightCount = 0;
                var colinearCount = 0;

                for (int k = 0; k < points.Count; k++)
                {
                    if (points[i] == points[k] || points[k] == points[j]) continue;
                    //skip if the point k is part of the segment

                    if (HelperMethods.CheckTurn(segment, points[k]) == Enums.TurnType.Left) leftCount++;
                    else if (HelperMethods.CheckTurn(segment, points[k]) == Enums.TurnType.Right) rightCount++;
                    else if (HelperMethods.CheckTurn(segment, points[k]) == Enums.TurnType.Colinear &&
                             points[k].X >= segment.Start.X && points[k].X <= segment.End.X &&
                             points[k].Y >= segment.Start.Y && points[k].Y <= segment.End.Y)
                        //point has to be colinear, but also lay on the segment
                        colinearCount++;
                } //get how many points are to the left or the right of the segment

                var sidePointsCount = points.Count - colinearCount - 2;
                //we exclude the 2 points that makes up the segment, as welll as the points that lay on it

                if (leftCount == sidePointsCount || rightCount == sidePointsCount)
                {
                    outLines.Add(segment);

                    outPointsHS.Add(segment.Start);
                    outPointsHS.Add(segment.End);
                }
            }

            outPoints = outPointsHS.ToList();
        }

        public override string ToString()
        {
            return "Convex Hull - Extreme Segments";
        }
    }
}