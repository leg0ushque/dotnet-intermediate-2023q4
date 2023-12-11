/*
 * Create a class based on ExpressionVisitor, which makes expression tree transformation:
 * 1. converts expressions like <variable> + 1 to increment operations, <variable> - 1 - into decrement operations.
 * 2. changes parameter values in a lambda expression to constants, taking the following as transformation parameters:
 *    - source expression;
 *    - dictionary: <parameter name: value for replacement>
 * The results could be printed in console or checked via Debugger using any Visualizer.
 */
using ExpressionTrees.Task1.ExpressionsTransformer.Visitors;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    public class Program
    {
        private static readonly IncDecExpressionVisitor _incDecVisitor = new IncDecExpressionVisitor();

        private static readonly TreeViewExpressionVisitor _treeViewVisitor = new TreeViewExpressionVisitor(Console.Out);

        private static void Main()
        {
            Console.WriteLine("Expression Visitor for increment/decrement.");

            Console.WriteLine("\n\nReplacing expressions like <variable> + 1 / <variable> - 1 with increment and decrement operations\n\n");

            Console.WriteLine("n => n.Value + 1");
            OutputBeforeAndAfter(n => n.Value + 1);

            Console.WriteLine("\n");

            Console.WriteLine("n => n.Value - 1");
            OutputBeforeAndAfter(n => n.Value - 1);

            Console.WriteLine("\n\nReplacing the parameters included in the lambda expression with constants:\n\n");
            DoParametersReplacement();

            Console.ReadLine();
        }

        private static void DoParametersReplacement()
        {
            Expression<Func<Number, int>> expression = n => 7 + n.Value - n.Value * 3;
            Console.WriteLine("n => 7 + n.Value - n.Value * 3");

            Console.WriteLine("BEFORE:");
            _treeViewVisitor.Visit(expression);

            var exchangeExpressionVisitor = new ConstantsReplacingExpressionVisitor(new[]
            {
                new KeyValuePair<ParameterExpression, object>(Expression.Parameter(typeof(Number), "nmb"), new Number { Value = 9 })
            });

            Console.WriteLine("AFTER:");

            var newExpression = (Expression<Func<int>>)exchangeExpressionVisitor.Visit(expression);
            _treeViewVisitor.Visit(newExpression);
        }

        private static void OutputBeforeAndAfter(Expression<Func<Number, int>> expression)
        {
            Console.WriteLine("BEFORE:");

            _treeViewVisitor.Visit(expression);

            Console.WriteLine("AFTER:");

             var modifiedExpression = _incDecVisitor.Visit(expression);
            _treeViewVisitor.Visit(modifiedExpression);
        }
    }
}
