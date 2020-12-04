using DesafioTecnicoMP.Models;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class PathArgumentTests
    {
        [Fact]
        public void Should_instanciate_correctly_by_specification()
        {
            var argument = new PathArgument(@"D:\dev");
            Assert.Equal("Path", argument.Name);
            Assert.Equal(@"D:\dev", argument.Value);
            Assert.Equal("-p", argument.Argument);
            Assert.True(argument.Required);
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instanciating_with_empty_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new PathArgument(""));
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instanciating_with_null_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new PathArgument(null));
        }
    }
}
