using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider.Handlers.MethodCallHandlers
{
    public class StringEndsWithCallHandler : StringBaseMethodCallHandler
    {
        public override string MethodName => nameof(string.EndsWith);

        public StringEndsWithCallHandler(ExpressionVisitor visitor, StringBuilder resultBuilder)
            : base(visitor, resultBuilder)
        {
        }

        protected override void HandleArgument(Expression argument)
        {
            ResultBuilder.Append("*");
            Visitor.Visit(argument);
        }
    }
}
