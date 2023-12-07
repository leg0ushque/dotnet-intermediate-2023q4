using ExpressionTrees.Task2.ExpressionMapping.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTrees.Task2.ExpressionMapping.Tests
{
    [TestClass]
    public class ExpressionMappingTests
    {
        private readonly MappingGenerator _mapGenerator = new MappingGenerator();

        [TestMethod]
        private void GivenSourceDestinationObjects_ShouldMapProperties()
        {
            // Arrange
            var mapper = _mapGenerator.GenerateExpressionMapper<Foo, Bar>();

            var src = new Foo
            {
                Integer = 7,
                Double = 3.1415,
                String = "Lorem ipsum",
                Bool = false,
            };

            // Act
            var dest = mapper.Map(src);

            // Assert
            Assert.IsTrue(src.Integer == dest.Integer
                          && src.Double == dest.Double
                          && src.String == dest.String
                          && src.Bool == dest.Bool);
        }
    }
}
