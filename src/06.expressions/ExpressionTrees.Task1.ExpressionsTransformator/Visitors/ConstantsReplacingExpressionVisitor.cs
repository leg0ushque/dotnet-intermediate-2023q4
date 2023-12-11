using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Visitors
{
    public partial class ConstantsReplacingExpressionVisitor : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, object> _parameterValuePairs;

        public ConstantsReplacingExpressionVisitor(IEnumerable<KeyValuePair<ParameterExpression, object>> parameterObjectPairs)
        {
            _parameterValuePairs = new Dictionary<ParameterExpression, object>(parameterObjectPairs, new NameTypeEqualityComparer());
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (!node.Parameters.Any())
            {
                return node;
            }

            var exchangedBody = Visit(node.Body);
            var lambdaWithoutParams = Expression.Lambda(exchangedBody);

            return base.Visit(lambdaWithoutParams);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_parameterValuePairs.TryGetValue(node, out var value))
            {
                return Expression.Constant(value);
            }

            return base.VisitParameter(node);
        }
    }
}
