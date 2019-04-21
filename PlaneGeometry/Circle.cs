using System;

namespace PlaneGeometry
{
    /// <summary>
    /// Circle
    /// </summary>
    public class Circle : IPlaneFigure
    {
        /// <summary>
        /// Radius
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Circle constructor
        /// </summary>
        /// <param name="radius">Radius</param>
        public Circle(double radius)
        {
            if (radius <= 0) { throw new ArgumentException("Nonpositive radius is prohibited"); }
            Radius = radius;
        }

        /// <summary>
        /// Area
        /// </summary>
        public double Area => Math.PI * Radius * Radius;

        /// <summary>
        /// Name of figure
        /// </summary>
        public string FigureName => "circle";
    }
}
