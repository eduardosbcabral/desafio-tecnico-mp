﻿using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class BufferLengthArgumentTests
    {
        [Fact]
        public void Should_instantiate_correctly_by_specification()
        {
            var argument = new BufferLengthArgument("10");
            Assert.Equal("Buffer Length", argument.Name);
            Assert.Equal(10485760L, argument.GetValue());
            Assert.Equal("-b", argument.Argument);
            Assert.False(argument.Required);
        }

        [Fact]
        public void Should_instantiate_correctly_when_value_is_default()
        {
            var argument = new BufferLengthArgument();
            Assert.Equal(1048576L, argument.GetValue());
        }

        [Fact]
        public void Should_value_be_default_when_instantiating_with_value_zero()
        {
            var argument = new BufferLengthArgument("0");
            Assert.Equal(1048576L, argument.GetValue());
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_instantiating_with_negative_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new BufferLengthArgument("-1"));
        }
    }
}
