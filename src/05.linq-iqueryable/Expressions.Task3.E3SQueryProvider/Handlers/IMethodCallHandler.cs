using System;
using System.Linq.Expressions;

namespace Expressions.Task3.E3SQueryProvider.Handlers
{
    public interface IMethodCallHandler
    {
        Type Type { get; }

        string MethodName { get; }

        void Invoke(MethodCallExpression node);
    }
}
