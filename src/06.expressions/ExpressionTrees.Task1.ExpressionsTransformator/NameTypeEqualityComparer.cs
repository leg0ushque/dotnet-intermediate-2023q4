using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Visitors
{
    internal class NameTypeEqualityComparer : IEqualityComparer<ParameterExpression>
    {
        public bool Equals(ParameterExpression x, ParameterExpression y)
        {
            return x.Name == y.Name
                && x.Type == y.Type;
        }

        public int GetHashCode(ParameterExpression obj)
        {
            return obj.Name.GetHashCode() + obj.Type.GetHashCode();
        }
    }
}
