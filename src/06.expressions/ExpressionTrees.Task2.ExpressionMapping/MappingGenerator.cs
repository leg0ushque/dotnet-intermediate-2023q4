using ExpressionTrees.Task2.ExpressionMapping.Utils;
using System;
using System.Linq.Expressions;

namespace ExpressionTrees.Task2.ExpressionMapping
{
    public class MappingGenerator
    {
        public Mapper<TSource, TDestination> GenerateExpressionMapper<TSource, TDestination>()
        {
            var propertyPairs = PropertiesHelper.GetPropertyPairs<TSource, TDestination>();
            var factoryExpression = MappingExpressionGenerator.GenerateExpression<TSource, TDestination>(propertyPairs);

            return new Mapper<TSource, TDestination>(factoryExpression.Compile());
        }

        public Mapper<TSource, TDestination> GeneratePropertiesMapper<TSource, TDestination>()
        {
            return new Mapper<TSource, TDestination>(source => PropertiesMapper.Map<TSource, TDestination>(source));
        }
    }
}
