using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class PathArgumentTests
    {
        [Fact]
        public void Should_instantiate_correctly_by_specification()
        {
            var argument = new PathArgument(@"D:\dev");
            Assert.Equal("Path", argument.Name);
            Assert.Equal(@"D:\dev", argument.GetValue());
            Assert.Equal("-p", argument.Argument);
            Assert.True(argument.Required);
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instantiating_with_empty_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new PathArgument(""));
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instantiating_with_null_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new PathArgument(null));
        }
    }
}
