using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Visitors
{
    public class IncDecExpressionVisitor : ExpressionVisitor
    {
        private const string One = "1";

        private readonly ExpressionType[] _leftExpressionTypes;
        private readonly Dictionary<ExpressionType, Func<Expression, Expression>> _nodeExpressionPairs;

        public IncDecExpressionVisitor()
        {
            _leftExpressionTypes = new[] { ExpressionType.Parameter, ExpressionType.MemberAccess };
            _nodeExpressionPairs = new Dictionary<ExpressionType, Func<Expression, Expression>>()
            {
                { ExpressionType.Add, expression => Expression.Increment(expression) },
                { ExpressionType.Subtract, expression => Expression.Decrement(expression) },
            };
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (!_nodeExpressionPairs.Keys.Contains(node.NodeType)
                || !_leftExpressionTypes.Contains(node.Left.NodeType))
            {
                return node;
            }

            if (node.Right is ConstantExpression constantExpression
                && constantExpression.Value.ToString() == One)
            {
                return _nodeExpressionPairs[node.NodeType].Invoke(node.Left);
            }

            return node;
        }
    }
}
