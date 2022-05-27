﻿using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class Incremental : PointBasedAlgo
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

            points.Sort();
            RemoveExactPoints(ref points);

            var next = new int[points.Count];
            var prev = new int[points.Count];

            var vis = new int[points.Count];

            next[0] = 1;
            next[1] = 0;

            prev[0] = 1;
            prev[1] = 0;

            for (var i = 2; i < points.Count; i++)
            {
                if (points[i].Y > points[i - 1].Y)
                {
                    next[i] = i - 1;
                    prev[i] = prev[i - 1];
                }
                else
                {
                    prev[i] = i - 1;
                    next[i] = next[i - 1];
                }

                next[prev[i]] = i;
                prev[next[i]] = i;

                while (HelperMethods.CheckTurn(new Line(points[i], points[prev[i]])
                           , points[prev[prev[i]]]) == Enums.TurnType.Right ||
                       HelperMethods.CheckTurn(new Line(points[i], points[prev[i]])
                           , points[prev[prev[i]]]) == Enums.TurnType.Colinear)
                {
                    next[prev[prev[i]]] = i;
                    prev[i] = prev[prev[i]];
                }

                while (HelperMethods.CheckTurn(new Line(points[next[next[i]]], points[next[i]])
                           , points[i]) == Enums.TurnType.Right ||
                       HelperMethods.CheckTurn(new Line(points[next[next[i]]], points[next[i]])
                           , points[i]) == Enums.TurnType.Colinear)
                {
                    prev[next[next[i]]] = i;
                    next[i] = next[next[i]];
                }
            }

            int node = 0;
            for (int i = 0; vis[node] == 0; i++)
            {
                vis[node] = 1;
                outPoints.Add(points[node]);
                node = next[node];
            }
        }

        public override string ToString()
        {
            return "Convex Hull - Incremental";
        }
    }
}