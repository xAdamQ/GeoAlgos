using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGUtilities
{
    /// <summary>
    /// The primary Point structure to be used in the CG project.
    /// </summary>
    public class Point : ICloneable, IComparable<Point>, IEquatable<Point>
    {
        /// <summary>
        /// Creates a point structure with the given coordinates.
        /// </summary>
        /// <param name="x">The X value/</param>
        /// <param name="y">The Y value.</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point start, Point end)
        {
            X = end.X - start.X;
            Y = end.Y - start.Y;
        }

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public double Y { get; set; }

        public static Point Identity
        {
            get { return new Point(0, 0); }
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p = (Point)obj;

                return Math.Abs(this.X - p.X) < Constants.Epsilon && Math.Abs(this.Y - p.Y) < Constants.Epsilon;
            }

            return false;
        }

        public static bool operator ==(Point point, Point other) => point.Equals(other as object);
        public static bool operator !=(Point point, Point other) => !(point == other);

        public bool Equals(Point other)
        {
            return this == other;
        }

        public static Point operator /(Point p, double d)
        {
            return new Point(p.X / d, p.Y / d);
        }

        public static Point operator -(Point p2, Point p)
        {
            return new Point(p2.X - p.X, p2.Y - p.Y);
        }

        public Point Vector(Point to)
        {
            return new Point(to.X - this.X, to.Y - this.Y);
        }

        public double Magnitude()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        public Point Normalize()
        {
            double mag = this.Magnitude();
            Point ans = this / mag;
            return ans;
        }

        /// <summary>
        /// Make a new instance of Point
        /// </summary>
        /// <returns>The new instance of Point</returns>
        public object Clone()
        {
            return new Point(X, Y);
        }

        public int CompareTo(Point other)
        {
            if (X == other.X) return Y.CompareTo(other.Y);
            return X.CompareTo(other.X);
        }
    }
}