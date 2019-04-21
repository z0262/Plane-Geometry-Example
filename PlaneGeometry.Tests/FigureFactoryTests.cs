using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaneGeometry.Tests
{
    /// <summary>
    /// Example class of plane figure. You do not need to register class. 
    /// </summary>
    public class FakeFigure : IPlaneFigure
    {
        /// <summary>
        /// Fake property
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a">fake parameter</param>
        public FakeFigure(double a)
        {
            A = a;
            if (a > 1)
            {
                throw new ArgumentException("Fake figure could not have parameter bigger than 1");
            }
        }

        /// <summary>
        /// Area
        /// </summary>
        public double Area => A;

        /// <summary>
        /// Name of figure
        /// </summary>
        public string FigureName => "fake";
    }

    /// <summary>
    /// Tests of figure factory
    /// </summary>
    public class FigureFactoryTests
    {
        [Test]
        public void CreatePlaneFigures()
        {
            var factory = new FigureFactory();
            var figures = factory.CreatePlaneFigures(new[] { 0.76 });
            Assert.IsNotNull(figures);
            Assert.AreEqual(2, figures.Count());
        }

        [Test]
        public void CreatePlaneFigureType()
        {
            var factory = new FigureFactory();
            var circle = factory.CreatePlaneFigure<Circle>(new[] { 0.77 });
            Assert.IsNotNull(circle);
            Assert.LessOrEqual(Math.Abs(circle.Area - 1.8626502843133884110845012619464), 0.00001);

            var fake = factory.CreatePlaneFigure<FakeFigure>(new[] { -1.0 });
            Assert.IsNotNull(fake);
            Assert.LessOrEqual(Math.Abs(fake.Area + 1.0), 0.00001);
        }

        [Test]
        public void CratePlaneFigureFirst()
        {
            var factory = new FigureFactory();
            var triangle = factory.CreatePlaneFigure(new[] { 1.4, 1.9, 2.7 });
            Assert.IsNotNull(triangle);
            Assert.AreEqual(typeof(Triangle), triangle.GetType());
            Assert.LessOrEqual(Math.Abs(triangle.Area - 1.2585706178041818563897442164159), 0.00001);

            var ellipse = factory.CreatePlaneFigure(new[] { 0.99, 1.1 });
            Assert.IsNotNull(ellipse);
            Assert.AreEqual(typeof(Ellipse), ellipse.GetType());
            Assert.LessOrEqual(Math.Abs(ellipse.Area - 3.4211943997592848366858186443914), 0.00001);

            var circle = factory.CreatePlaneFigure(new[] { 1.1 });
            Assert.IsNotNull(circle);
            Assert.AreEqual(typeof(Circle), circle.GetType());
            Assert.LessOrEqual(Math.Abs(circle.Area - 3.8013271108436498185397984937682), 0.00001);

        }
    }
}
