using System;

namespace ExpressionTrees.Task2.ExpressionMapping.Utils
{
    public static class PropertiesMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var destination = (TDestination)typeof(TDestination).GetConstructor(Array.Empty<Type>())
                  .Invoke(Array.Empty<object>());

            foreach (var propPair in PropertiesHelper.GetPropertyPairs<TSource, TDestination>())
            {
                var srcProp = propPair.Key;
                var destProp = propPair.Value;
                var sourceValue = srcProp.GetValue(source);

                if (srcProp.PropertyType != destProp.PropertyType)
                {
                    sourceValue = Convert.ChangeType(sourceValue, destProp.PropertyType);
                }

                destProp.SetValue(destination, sourceValue);
            }

            return destination;
        }
    }
}
