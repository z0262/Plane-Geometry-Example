using System;

namespace PlaneGeometry
{
    /// <summary>
    /// Ellipse
    /// </summary>
    public class Ellipse : IPlaneFigure
    {
        /// <summary>
        /// First radius
        /// </summary>
        public double R1 { get; set; }

        /// <summary>
        /// Second radius
        /// </summary>
        public double R2 { get; set; }

        /// <summary>
        /// Ellipse constructor
        /// </summary>
        /// <param name="r1">first radius</param>
        /// <param name="r2">second radius</param>
        public Ellipse(double r1, double r2)
        {
            if (r1 <= 0 || r2 <= 0) { throw new ArgumentException("Nonpositive radius is prohibited"); }
            R1 = r1;
            R2 = r2;
        }

        /// <summary>
        /// Area
        /// </summary>
        public double Area => Math.PI * R1 * R2;

        /// <summary>
        /// Name of figure
        /// </summary>
        public string FigureName => IsCircle ? "round ellipse" : "ellipse";

        /// <summary>
        /// Is true when ellipse is circle; otherwise false; 
        /// </summary>
        public bool IsCircle => R1 == R2;
    }
}
