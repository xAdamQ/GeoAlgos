using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class JarvisMarch : PointBasedAlgo
    {
        // public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
        //     ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        // {
        //     base.Run(points, lines, polygons, ref outPoints, ref outLines, ref outPolygons);
        //
        //     RemoveExactPoints(ref points);
        //     if (points.Count < 3)
        //     {
        //         outPoints.AddRange(points);
        //         return;
        //     }
        //
        //     #region MyRegion
        //
        //     // var basePoint = points.OrderBy(p => p.X).First();
        //     // //the first extreme point will be left
        //     //
        //     // var remainingPoints = new List<Point>(points);
        //     //
        //     // outPoints.Add(basePoint);
        //     //
        //     // while (true)
        //     // {
        //     //     var minDistance = double.MaxValue;
        //     //     var minAngle = double.MaxValue;
        //     //
        //     //     Point candidate = default;
        //     //     var last = outPoints.Count > 1 ? outPoints.Last() : new Point(basePoint.X, 999);
        //     //     var current = outPoints.Count > 1 ? outPoints[outPoints.Count - 2] : outPoints[0];
        //     //
        //     //     var dirVec = new Line(last - current);
        //     //     foreach (var point in remainingPoints)
        //     //     {
        //     //         if (point == current || point == last)
        //     //             continue;
        //     //
        //     //         var angle = dirVec.AngleWith(point - last);
        //     //         var distance = HelperMethods.distance(current, point);
        //     //
        //     //         if (angle > minAngle) continue;
        //     //
        //     //         if (angle < minAngle)
        //     //         {
        //     //             minAngle = angle;
        //     //             candidate = point;
        //     //
        //     //             minDistance = distance;
        //     //         }
        //     //         else if (HelperMethods.distance(current, point) < minDistance) //angles are equal
        //     //         {
        //     //             candidate = point;
        //     //             minDistance = distance;
        //     //         }
        //     //     }
        //     //
        //     //     if (current != basePoint)
        //     //         outLines.Add(new Line(last, candidate));
        //     //
        //     //     if (candidate == basePoint)
        //     //         break;
        //     //
        //     //     outPoints.Add(candidate);
        //     //     remainingPoints.Remove(candidate);
        //     // }
        //
        //     #endregion
        //
        //
        //     Line l = new Line(basePoint, new Point(basePoint.X + 9999999, basePoint.Y));
        //     // get the base point and make the start line
        //
        //     double minAngle = double.MaxValue;
        //     for (int i = 0; i < points.Count; i++)
        //     {
        //         if (points[i] == l.Start || points[i] == l.End) continue;
        //
        //         var angle = l.AngleWith(new Line(l.Start, points[i]));
        //
        //         if (angle <= minAngle)
        //         {
        //             minAngle = angle;
        //             ind = i;
        //         }
        //     }
        //
        //     get minAngle
        //         l = new Line(points[ind], points[0]);
        //     outLines.Add(l);
        //
        //
        //     var prevAngle = -1;
        //
        //     while (true)
        //     {
        //         var prevPoint = basePoint;
        //         var minAngle = double.MaxValue;
        //         var maxDist = 0;
        //         foreach (var point in points)
        //         {
        //             var candidateLine = new Line(point);
        //             var angle = l.AngleWith(candidateLine);
        //             var dist = HelperMethods.distance(prevPoint, point);
        //
        //             if (angle <= minAngle)
        //             {
        //                 minAngle = angle;
        //             }
        //             else if (angle == minAngle && dist)
        //             {
        //             }
        //         }
        //     }
        //
        //     while (true)
        //     {
        //         minAngle = double.MaxValue;
        //         double dis = double.MinValue;
        //         int ind1 = ind;
        //         for (int i = 0; i < points.Count; i++)
        //         {
        //             if (points[i].Equals(l.Start) || points[i].Equals(l.End)) continue;
        //
        //             var angle = l.AngleWith(new Line(l.Start, points[i]));
        //
        //             if (angle < 0)
        //                 angle += 360;
        //             if (angle == minAngle && dis < HelperMethods.distance(l.Start, points[i]))
        //             {
        //                 ind = i;
        //                 dis = HelperMethods.distance(l.Start, points[i]);
        //             }
        //             else if (angle < minAngle && angle > 0)
        //             {
        //                 minAngle = angle;
        //                 ind = i;
        //                 dis = HelperMethods.distance(l.Start, points[i]);
        //             }
        //         }
        //
        //         if (minAngle == 0 || points[ind].Equals(l.Start) || points[ind].Equals(l.End))
        //             break;
        //         l = new Line(points[ind], points[ind1]);
        //         outLines.Add(l);
        //         if (ind == 0)
        //             break;
        //     }
        //
        //
        //     for (int i = 0; i < outLines.Count; i++)
        //     {
        //         bool ff = true;
        //         for (int ii = 0; ii < outPoints.Count; ii++)
        //         {
        //             if (outLines[i].Start.Equals(outPoints[ii]))
        //             {
        //                 ff = false;
        //                 break;
        //             }
        //         }
        //
        //         if (ff == true)
        //         {
        //             outPoints.Add(outLines[i].Start);
        //         }
        //
        //         ff = true;
        //         for (int ii = 0; ii < outPoints.Count; ii++)
        //         {
        //             if (outLines[i].End.Equals(outPoints[ii]))
        //             {
        //                 ff = false;
        //                 break;
        //             }
        //         }
        //
        //         if (ff == true)
        //         {
        //             outPoints.Add(outLines[i].End);
        //         }
        //     }
        //
        //     public static Point[] ConvexHull(Point[] points)
        //     {
        //         List<Point> hull = new List<Point>();
        //
        //         if (points.Length < 3) return null; // we need at least three points for the algorithm    
        //         //Traverse the poligon to find the leftmost point, which will be our starting point
        //         // O(n)
        //         int leftmost = 0;
        //         for (int i = 1; i < points.Length; ++i)
        //             if (points[i].X < points[leftmost].X)
        //                 leftmost = i;
        //         // Now we have found the starting point
        //
        //
        //         int current = leftmost; //the current point will always be considered to be the leftmost point 
        //         // the ones left to it were already added to the hull
        //
        //         int next; // next point to add in hull will be the rightmost to the current point 
        //         //   (cel mai la dreapta fata de punctul curent )
        //
        //         //Go counterclockwise until we reach the starting point again,
        //         do // O(h) , h - number of points in convex hull
        //         {
        //             // Console.WriteLine("Added : " + poligon[current]); //DEBUG
        //
        //             // Add current point to hull
        //             hull.Add(points[current]);
        //
        //             // VISUAL TIP : hull[hull.Count - 1] gets connected to hull[hull.Count -2 ] - final color
        //
        //             //We choose the next point to add in hull :
        //
        //             //initially the next point in the poligon
        //             next = (current + 1) % points.Length; //we use modulo n to get back to 0 if "current == length - 1"
        //
        //             // Console.WriteLine("Next is : " + poligon[next]); //DEBUG
        //
        //             //traverse all the points to find the next one to add in hull
        //             for (int i = 0; i < points.Length; ++i)
        //             {
        //                 //VISUAL TIP: color the line poligon[current] - poligon[next] - intermediary color
        //
        //                 if (i == current || i == next) //unecessary to check for these
        //                     continue;
        //
        //                 //If P[i] is to the right of the edge Current-Next, we update Next
        //                 //So if there is a point more to the right of Current than Next currently is, we update Next
        //                 //Thus, at each step, we will always choose the rightmost point to the current one
        //
        //                 double direction = points[i].Line_eq(points[current], points[next]);
        //
        //                 // if P[i] is to the right of line Current-Next, update next
        //                 if (direction < 0)
        //                     next = i;
        //
        //                 //if P[i] is on the line Current-Next
        //                 //and if Next is on the segment Current--P[i], update next
        //                 if (direction == 0 && points[current].DistTo(points[i]) > points[current].DistTo(points[next]))
        //                     next = i;
        //             }
        //
        //             //Console.WriteLine("Next gets : " + poligon[next]); //DEBUG
        //
        //
        //             //foreach (Point p in hull) //DEBUG
        //             //    Console.Write(p + "  ");
        //             //Console.Write("\n\n");
        //
        //             current = next; // we update the current point to add it in the hull
        //         } while (current != leftmost); // When we reach leftmost, we reached the starting point, so we finished
        //
        //         return hull.ToArray();
        //     }
        // }

        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons,
            ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            base.Run(points, lines, polygons, ref outPoints, ref outLines, ref outPolygons);

            points.Sort();
            RemoveExactPoints(ref points);

            var basePoint = points.OrderBy(p => p.Y).First();
            var current = basePoint;

            var line = new Line(basePoint, new Point(basePoint.X + 9999, basePoint.Y));

            var minAngle = double.MaxValue;
            foreach (var point in points)
            {
                if (point.Equals(line.Start) || point.Equals(line.End)) continue;

                var angle = new Line(line.End - line.Start).AngleWith(point - line.Start);

                if (angle < 0) angle += 360; //normalize angle

                if (angle > minAngle) continue;

                minAngle = angle;
                current = point;
            }
            //make the first segment because it's special

            line = new Line(current, basePoint);
            outLines.Add(line);

            while (true)
            {
                minAngle = double.MaxValue;
                var maxDistance = double.MinValue;
                var first = current;

                foreach (var point in points)
                {
                    if (point.Equals(line.Start) || point.Equals(line.End)) continue;

                    var angle = new Line(line.End - line.Start).AngleWith(point - line.Start);

                    if (angle > minAngle || angle == 0) continue;
                    //avoid 0 angle special case

                    if (angle < 0) angle += 360; //normalize angle

                    if (angle == minAngle && maxDistance < HelperMethods.distance(line.Start, point))
                    {
                        current = point;
                        maxDistance = HelperMethods.distance(line.Start, point);
                    }
                    else if (angle < minAngle)
                    {
                        minAngle = angle;
                        current = point;
                        maxDistance = HelperMethods.distance(line.Start, point);
                    }
                }

                line = new Line(current, first);
                outLines.Add(line);

                if (current == basePoint)
                    break;
            }

            outPoints = outLines.Select(l => l.Start).Concat(outLines.Select(l => l.End)).Distinct().ToList();
        }

        public override string ToString()
        {
            return "Convex Hull - Jarvis March";
        }
    }
}