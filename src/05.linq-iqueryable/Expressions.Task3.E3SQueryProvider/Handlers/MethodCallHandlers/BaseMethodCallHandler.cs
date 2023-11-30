using System;
using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider.Handlers.MethodCallHandlers
{
    public abstract class BaseMethodCallHandler : IMethodCallHandler
    {
        public abstract Type Type { get; }

        public abstract string MethodName { get; }

        protected ExpressionVisitor Visitor { get; }

        protected StringBuilder ResultBuilder { get; }

        protected BaseMethodCallHandler(ExpressionVisitor visitor, StringBuilder resultBuilder)
        {
            Visitor = visitor;
            ResultBuilder = resultBuilder;
        }

        public abstract void Invoke(MethodCallExpression node);
    }
}
