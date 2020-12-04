﻿using DesafioTecnicoMP.Models;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class FileSizeArgumentTests
    {
        [Fact]
        public void Should_instanciate_correctly_by_specification()
        {
            var argument = new FileSizeArgument(10L);
            Assert.Equal("File Size", argument.Name);
            Assert.Equal(10L, argument.Value);
            Assert.Equal("-f", argument.Argument);
            Assert.False(argument.Required);
        }

        [Fact]
        public void Should_instanciate_correctly_when_value_is_default()
        {
            var argument = new FileSizeArgument();
            Assert.Equal(104857600L, argument.Value);
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instanciating_with_value_zero()
        {
            Assert.Throws<ApplicationArgumentException>(() => new FileSizeArgument(0));
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instanciating_with_negative_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new FileSizeArgument(-1));
        }
    }
}
