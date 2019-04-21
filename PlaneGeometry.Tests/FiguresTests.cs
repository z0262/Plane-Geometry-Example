using NUnit.Framework;
using PlaneGeometry;
using System;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Tests of figures
    /// </summary>
    public class FigureTests
    {
        [Test]
        public void TestCircle()
        {
            var instance = new Circle(0.51);
            Assert.IsTrue(instance.FigureName == "circle");
            Assert.LessOrEqual(Math.Abs(instance.Area - 0.817128249198705221324133543991), 0.00001);

            ParallelEnumerable.Range(-1, 2).ForAll(x => Assert.Catch<ArgumentException>(() => new Circle(x)));
        }

        [Test]
        public void TestTriangle()
        {
            var instance = new Triangle(0.51, 1.1, 0.9);
            Assert.IsTrue(instance.FigureName == "triangle");
            Assert.IsFalse(instance.IsRightTriangle);
            Assert.LessOrEqual(Math.Abs(instance.Area - 0.22681930996941155494888055833816), 0.00001);

            new[] { -1, 0, 3 }.AsParallel().ForAll(x =>
            {
                Assert.Catch<ArgumentException>(() => new Triangle(x, 1, 1));
                Assert.Catch<ArgumentException>(() => new Triangle(1, x, 1));
                Assert.Catch<ArgumentException>(() => new Triangle(1, 1, x));
                if (x < 1)
                {
                    Assert.Catch<ArgumentException>(() => new Triangle(x, x, 1));
                    Assert.Catch<ArgumentException>(() => new Triangle(x, 1, x));
                    Assert.Catch<ArgumentException>(() => new Triangle(1, x, x));
                    Assert.Catch<ArgumentException>(() => new Triangle(x, x, x));
                }
            });
        }

        [Test]
        public void TestEllipse()
        {
            var instance = new Ellipse(0.51, 1.1);
            Assert.IsTrue(instance.FigureName == "ellipse");
            Assert.IsFalse(instance.IsCircle);
            Assert.LessOrEqual(Math.Abs(instance.Area - 1.7624334786638740067775429380198), 0.00001);

            ParallelEnumerable.Range(-1, 2).ForAll(x =>
            {
                Assert.Catch<ArgumentException>(() => new Ellipse(x, 1));
                Assert.Catch<ArgumentException>(() => new Ellipse(1, x));
                Assert.Catch<ArgumentException>(() => new Ellipse(x, x));
            });
        }

        [Test]
        public void TestRoundEllipse()
        {
            var instance = new Ellipse(1.1, 1.1);
            Assert.IsTrue(instance.FigureName == "round ellipse");
            Assert.IsTrue(instance.IsCircle);
            Assert.LessOrEqual(Math.Abs(instance.Area - 3.8013271108436498185397984937682), 0.00001);
        }

        [Test]
        public void TestRightTriangle()
        {
            var instance = new Triangle(3, 4, 5);
            Assert.IsTrue(instance.FigureName == "right triangle");
            Assert.IsTrue(instance.IsRightTriangle);
            Assert.LessOrEqual(Math.Abs(instance.Area - 6), 0.00001);
        }
    }
}