using System;
using System.Linq;

namespace PlaneGeometry
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle : IPlaneFigure
    {
        /// <summary>
        /// Length of first side
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Length of second side
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Length of third side
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Triangle constructor
        /// </summary>
        /// <param name="a">Length of first side</param>
        /// <param name="b">Length of second side</param>
        /// <param name="c">Length of third side</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) { throw new ArgumentException("Nonpositive length is prohibited"); }
            if ((a - b - c) >= 0 || (b - a - c) >= 0 || (c - a - b) >= 0)
            {
                throw new ArgumentException($"Triangle with sides {a} {b} {c} could not be constructed on the plane (Euclidean geometry).");
            }
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Area
        /// </summary>
        public double Area
        {
            get
            {
                var p = 0.5 * (A + B + C);
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        /// <summary>
        /// Name of figure
        /// </summary>
        public string FigureName => IsRightTriangle ? "right triangle" : "triangle";

        /// <summary>
        /// Is true when the triangle is right; otherwise false
        /// </summary>
        public bool IsRightTriangle
        {
            get
            {
                return Math.Abs(new[] { A, B, C }
                    .OrderByDescending(x => x)
                    .Select((x, i) => i == 0 ? -(x * x) : x * x)
                    .Sum()) <= 0.00001;
            }
        }
    }
}
