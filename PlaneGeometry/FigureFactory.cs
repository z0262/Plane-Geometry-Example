using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlaneGeometry
{
    /// <summary>
    /// Factory of plane figures.
    /// </summary>
    public class FigureFactory
    {
        /// <summary>
        /// Create all known figures by parameters
        /// </summary>
        /// <param name="pars">parameters of figure</param>
        /// <param name="outputType">output type</param>
        /// <returns>array of plane figures</returns>
        public IEnumerable<IPlaneFigure> CreatePlaneFigures(double[] pars, Type outputType = null)
        {
            if (pars == null || pars.Length < 1 || !_refs.ContainsKey(pars.Length)) { return null; }
            var refs = _refs[pars.Length];
            IEnumerable<ConstructorInfo> constructors = outputType == null
                ? refs
                : refs?.Where(c => c.DeclaringType == outputType);
            return constructors
                ?.OrderBy(c => c.DeclaringType.Name)
                .Select(c =>
                {
                    try
                    {
                        return c.Invoke(pars.OfType<object>().ToArray());
                    }
                    catch (TargetInvocationException e)
                    {
                        throw e.InnerException ?? e;
                    }
                })
                .OfType<IPlaneFigure>();
        }

        /// <summary>
        /// Create first figure with parameters
        /// </summary>
        /// <param name="pars">parameters of figure</param>
        /// <returns>plane figure</returns>
        public IPlaneFigure CreatePlaneFigure(double[] pars)
        {
            return CreatePlaneFigures(pars)?.FirstOrDefault();
        }

        /// <summary>
        /// Create figure of specified type
        /// </summary>
        /// <typeparam name="T">type of figure</typeparam>
        /// <param name="pars">parameters of figure</param>
        /// <returns>plane figure</returns>
        public T CreatePlaneFigure<T>(double[] pars) where T: IPlaneFigure
        {
            return (CreatePlaneFigures(pars, typeof(T)) ?? Enumerable.Empty<IPlaneFigure>()).OfType<T>().FirstOrDefault();
        }

        private readonly static Dictionary<int, ConstructorInfo[]> _refs;
        
        static FigureFactory()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IPlaneFigure).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToArray();
            var constructors = types
                .SelectMany(t => t.GetConstructors())
                .ToArray();
            _refs = constructors 
                .Where(c => c.GetParameters().All(p => p.ParameterType == typeof(double)))
                .GroupBy(c => c.GetParameters().Count())
                .Where(gc => gc.Key > 0)
                .ToDictionary(gc => gc.Key, gc => gc.ToArray());
        }
    }
}
