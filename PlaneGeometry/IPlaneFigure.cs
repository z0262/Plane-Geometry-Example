namespace PlaneGeometry
{
    /// <summary>
    /// Plane figure interface
    /// </summary>
    public interface IPlaneFigure
    {
        /// <summary>
        /// Area
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Name of figure
        /// </summary>
        string FigureName { get; }
    }
}
