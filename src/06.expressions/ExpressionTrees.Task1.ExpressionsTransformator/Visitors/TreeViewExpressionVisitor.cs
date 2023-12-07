using System;
using System.IO;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Visitors
{
    public class TreeViewExpressionVisitor : ExpressionVisitor
    {
        private int _offset;
        private readonly TextWriter _textWriter;

        private string Offset
        {
            get { return new string('\t', _offset); }
        }

        public TreeViewExpressionVisitor(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            ViewAndVisit(() => { }, () => Visit(node.Left));

            _textWriter.WriteLine($"{Offset}{node.NodeType}");

            ViewAndVisit(() => { }, () => Visit(node.Right));

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}Const:{node.Value}"),
                () => base.VisitConstant(node)
            );
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}Lambda:{node.Name}"),
                () => base.VisitLambda(node)
            );
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}Member:{node.Member.DeclaringType.Name}.{node.Member.Name}"),
                () => base.VisitMember(node)
            );
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}MethodCall:{node.Method.DeclaringType}.{node.Method.Name}"),
                () => base.VisitMethodCall(node)
            );
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}Parameter:{node.Type.Name} {node.Name}"),
                () => base.VisitParameter(node)
            );
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return ViewAndVisit(
                () => _textWriter.WriteLine($"{Offset}{node.NodeType}"),
                () => base.VisitUnary(node)
            );
        }

        private Expression ViewAndVisit(Action viewNode, Func<Expression> getResult)
        {
            viewNode();

            _offset++;
            var result = getResult();
            _offset--;

            return result;
        }
    }
}
