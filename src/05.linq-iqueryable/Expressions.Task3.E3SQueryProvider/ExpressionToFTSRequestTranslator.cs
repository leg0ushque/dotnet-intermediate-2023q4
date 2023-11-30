using Expressions.Task3.E3SQueryProvider.Factories;
using Expressions.Task3.E3SQueryProvider.Handlers;
using Expressions.Task3.E3SQueryProvider.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Expressions.Task3.E3SQueryProvider
{
    public class ExpressionToFtsRequestTranslator : ExpressionVisitor
    {
        private Dictionary<(Type, string), IMethodCallHandler> _methodCallHandlers;
        readonly StringBuilder _resultStringBuilder;

        public ExpressionToFtsRequestTranslator()
        {
            _resultStringBuilder = new StringBuilder();
            _methodCallHandlers = MethodCallHandlerFactory.GetCallHandlers(this, _resultStringBuilder)
                .ToDictionary(s => (s.Type, s.MethodName));
        }

        public string Translate(Expression exp)
        {
            Visit(exp);

            return _resultStringBuilder.ToString();
        }

        #region protected methods

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(Queryable)
                && node.Method.Name == nameof(Queryable.Where))
            {
                var predicate = node.Arguments[1];

                Visit(predicate);

                return node;
            }

            if (node.Method.DeclaringType == typeof(string))
            {
                Visit(node.Object);

                var firstArgument = node.Arguments.First();

                _resultStringBuilder.Append("(");

                switch (node.Method.Name)
                {
                    case nameof(string.StartsWith):
                        Visit(firstArgument);
                        _resultStringBuilder.Append("*");
                        break;

                    case nameof(string.EndsWith):
                        _resultStringBuilder.Append("*");
                        Visit(firstArgument);
                        break;

                    case nameof(string.Contains):
                        _resultStringBuilder.Append("*");
                        Visit(firstArgument);
                        _resultStringBuilder.Append("*");
                        break;

                    case nameof(string.Equals):
                        Visit(firstArgument);
                        break;
                }

                _resultStringBuilder.Append(")");

                return node;
            }

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.AndAlso)
            {
                var ftsRequest = new FtsQueryRequest();

                ftsRequest.Statements.AddRange(new[]
                {
                    new Statement { Query = GetValueAfterVisiting(node.Left) },
                    new Statement { Query = GetValueAfterVisiting(node.Right) }
                });

                var serializedRequest = JsonConvert.SerializeObject(ftsRequest, Formatting.Indented);
                _resultStringBuilder.Append(serializedRequest);
            }
            else if (node.NodeType == ExpressionType.Equal)
            {
                ValidateAccessableExpression(node.Left);
                ValidateAccessableExpression(node.Right);

                var allExpressions = GetAccessableExpressions(node);

                Visit(allExpressions.member);
                _resultStringBuilder.Append("(");
                Visit(allExpressions.constant);
                _resultStringBuilder.Append(")");
            }

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _resultStringBuilder.Append(node.Member.Name).Append(":");

            return base.VisitMember(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _resultStringBuilder.Append(node.Value);

            return node;
        }

        #endregion

        private void ValidateAccessableExpression(Expression node)
        {
            if (node.NodeType != ExpressionType.MemberAccess && node.NodeType != ExpressionType.Constant)
            {
                throw new NotSupportedException($"Operand should be a field or a property, or a constant: {node.NodeType}");
            }
        }

        private (Expression member, Expression constant) GetAccessableExpressions(BinaryExpression node)
        {
            var allExpressions = new[] { node.Left, node.Right }
                .OrderByDescending(expression => expression.NodeType);

            return (allExpressions.First(), allExpressions.Last());
        }

        private string GetValueAfterVisiting(Expression node)
        {
            Visit(node);

            var query = _resultStringBuilder.ToString();
            _resultStringBuilder.Clear();

            return query;
        }
    }
}
