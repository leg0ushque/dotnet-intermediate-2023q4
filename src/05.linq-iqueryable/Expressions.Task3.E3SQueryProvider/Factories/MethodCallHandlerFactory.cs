using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Expressions.Task3.E3SQueryProvider.Handlers;

namespace Expressions.Task3.E3SQueryProvider.Factories
{
    internal class MethodCallHandlerFactory
    {
        public static IMethodCallHandler[] GetCallHandlers(ExpressionVisitor expressionVisitor, StringBuilder resultBuilder)
        {
            return Assembly.GetExecutingAssembly().DefinedTypes
                .Where(type => !type.IsAbstract && typeof(IMethodCallHandler).IsAssignableFrom(type))
                .Select(type => (IMethodCallHandler)Activator.CreateInstance(type, expressionVisitor, resultBuilder))
                .ToArray();
        }
    }
}
