using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider.Handlers.MethodCallHandlers
{
    public class QueryableWhereCallHandler : BaseMethodCallHandler
    {
        private const int PredicateIndex = 1;

        public override Type Type => typeof(Queryable);

        public override string MethodName => nameof(Queryable.Where);

        public QueryableWhereCallHandler(ExpressionVisitor visitor, StringBuilder resultBuilder)
            : base(visitor, resultBuilder)
        {
        }

        public override void Invoke(MethodCallExpression node)
        {
            var predicate = node.Arguments[PredicateIndex];
            Visitor.Visit(predicate);
        }
    }
}
