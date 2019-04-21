using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace PlaneGeometry.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
                var values = args
                    .Select(x => Double.TryParse(x, out var val) ? val : (double?)null)
                    .Where(x => x.HasValue)
                    .Select(x => x.Value)
                    .ToArray();
                var figures = new FigureFactory().CreatePlaneFigures(values)?.ToArray();
                if ((figures?.Length ?? 0) < 1)
                {
                    Console.WriteLine(@"Help: all parameters should be floating point values.
For example:
1.33 2.112 3.1");
                    return;
                }
                foreach (var figure in figures)
                {
                    if (figure == null) { continue; }
                    Console.WriteLine($"Created figure: {figure.FigureName} ({string.Join(";", values)}) with area {figure.Area}");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Area could not be calculated: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
