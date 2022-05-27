using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGUtilities
{
    /// <summary>
    /// The primary Line structure to be used in the CG project.
    /// </summary>
    public class Line : ICloneable
    {
        public Line(Point end) : this(new Point(0, 0), end)
        {

        }

        /// <summary>
        /// Creates a line structure that has the specified start/end.
        /// </summary>
        /// <param name="start">The start point.</param>
        /// <param name="end">The end point.</param>
        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Creates a line structure that has the specified start/end.
        /// </summary>
        /// <param name="X1">The X value for the start point.</param>
        /// <param name="Y1">The Y value for the start point.</param>
        /// <param name="X2">The X value for the end point.</param>
        /// <param name="Y2">The Y value for the end point.</param>
        public Line(double X1, double Y1, double X2, double Y2)
            : this(new Point(X1, Y1), new Point(X2, Y2))
        {
        }

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        public Point Start
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        public Point End
        {
            get;
            set;
        }
        /// <summary>
        /// Instantiate Line
        /// </summary>
        /// <returns>new instance of Line</returns>
        public object Clone()
        {
            return new Line((Point)Start.Clone(), (Point)End.Clone());
        }


        public double AngleWith(Line line)
        {
            var v1 = End - Start;
            var v2 = line.End - line.Start;

            var cros = HelperMethods.CrossProduct(v1, v2);
            var dot = HelperMethods.DotProduct(v1, v2);

            return Math.Atan2(cros, dot) * (180 / Math.PI);
        }

        /// <summary>
        /// ATTENTION: is the angle set right?
        /// </summary>
        public double AngleWith(Point point)
        {
           return AngleWith(new Line(Start, point));
        }

        public Point ToVector()
        {
            return new Point(End.X - Start.X, End.Y - Start.Y);
        }

        //double orientation(Point r)
        //{
        //    var p = Start;
        //    var q = End;
            
        //    double val = (q.Y - p.Y) * (r.X - q.X) -
        //              (q.X - p.X) * (r.Y - q.Y);
        //    if (val == 0) return 0;      // colinear
        //    return (val > 0) ? 1 : 2;   // clock or counterclock wise
        //}

    }
}
