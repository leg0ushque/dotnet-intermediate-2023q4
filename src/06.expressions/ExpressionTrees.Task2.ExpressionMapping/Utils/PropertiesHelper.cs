using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpressionTrees.Task2.ExpressionMapping.Utils
{
    public static class PropertiesHelper
    {
        public static Dictionary<PropertyInfo, PropertyInfo> GetPropertyPairs<TSource, TDestination>()
        {
            var srcAccessibleProperties = GetAccessibleProperties<TSource>();
            var destAccessibleProperties = GetAccessibleProperties<TDestination>();

            var propertyPairs = srcAccessibleProperties.Join(destAccessibleProperties,
                srcProp => srcProp.Name,
                destProp => destProp.Name,
                (sourceProp, destinationProp) => new
                {
                    SourceProperty = sourceProp,
                    DestinationProperty = destinationProp
                });

            return propertyPairs.ToDictionary(pair => pair.SourceProperty, pair => pair.DestinationProperty);
        }

        private static IEnumerable<PropertyInfo> GetAccessibleProperties<TElement>()
        {
            return typeof(TElement).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.CanWrite && prop.CanRead);
        }
    }
}
