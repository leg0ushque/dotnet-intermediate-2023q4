using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider.Handlers.MethodCallHandlers
{
    public abstract class StringBaseMethodCallHandler : BaseMethodCallHandler
    {
        public override Type Type => typeof(string);

        protected StringBaseMethodCallHandler(ExpressionVisitor visitor, StringBuilder resultBuilder)
            : base(visitor, resultBuilder)
        {
        }

        public override void Invoke(MethodCallExpression node)
        {
            Visitor.Visit(node.Object);
            var firstArgument = node.Arguments.First();

            ResultBuilder.Append("(");
            HandleArgument(firstArgument);
            ResultBuilder.Append(")");
        }

        protected abstract void HandleArgument(Expression argument);
    }
}
