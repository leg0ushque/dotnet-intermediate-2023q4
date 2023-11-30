using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider.Handlers.MethodCallHandlers
{
    public class StringEqualsCallHandler : StringBaseMethodCallHandler
    {
        public override string MethodName => nameof(string.Equals);

        public StringEqualsCallHandler(ExpressionVisitor visitor, StringBuilder resultBuilder)
            : base(visitor, resultBuilder)
        {
        }

        protected override void HandleArgument(Expression argument)
        {
            Visitor.Visit(argument);
        }
    }
}
