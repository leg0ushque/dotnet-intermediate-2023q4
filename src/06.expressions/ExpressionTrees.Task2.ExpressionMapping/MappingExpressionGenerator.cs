using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTrees.Task2.ExpressionMapping
{
    public class MappingExpressionGenerator
    {
        public static Expression<Func<TSource, TDestination>> GenerateExpression<TSource, TDestination>(IDictionary<PropertyInfo, PropertyInfo> propertyPairs)
        {
            var expressionParameter = Expression.Parameter(typeof(TSource));
            var memberAssignments = propertyPairs.Select(pair => CreateMemberAssignment(expressionParameter, pair.Key, pair.Value));
            var expressionBody = Expression.MemberInit(Expression.New(typeof(TDestination)), memberAssignments);

            return Expression.Lambda<Func<TSource, TDestination>>(expressionBody, expressionParameter);
        }

        private static MemberAssignment CreateMemberAssignment(Expression source, PropertyInfo sourceProperty, PropertyInfo destinationProperty)
        {
            if (sourceProperty.PropertyType == destinationProperty.PropertyType)
            {
                return Expression.Bind(destinationProperty, Expression.Property(source, sourceProperty));
            }

            var methodInfo = typeof(Convert).GetMethod(nameof(Convert.ChangeType), new[] { typeof(object), typeof(Type) });
            var methodCall = Expression.Call(instance: null,
                methodInfo,
                Expression.Convert(Expression.Property(source, sourceProperty), typeof(object)),
                Expression.Constant(destinationProperty.PropertyType)
            );

            return Expression.Bind(destinationProperty, Expression.Convert(methodCall, destinationProperty.PropertyType));
        }
    }
}
