﻿using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using System;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class FileSizeArgumentTests
    {
        [Fact]
        public void Should_instantiate_correctly_by_specification()
        {
            var argument = new FileSizeArgument("10");
            Assert.Equal("File Size", argument.Name);
            Assert.Equal(10485760L, argument.GetValue());
            Assert.Equal("-f", argument.Argument);
            Assert.False(argument.Required);
        }

        [Fact]
        public void Should_instantiate_correctly_when_value_is_default()
        {
            var argument = new FileSizeArgument();
            Assert.Equal(104857600L, argument.GetValue());
        }

        [Fact]
        public void Should_value_be_default_when_instantiating_with_value_zero()
        {
            var argument = new FileSizeArgument("0");
            Assert.Equal(104857600L, argument.GetValue());
        }

        [Fact]
        public void Should_throw_ArgumentException_when_instantiating_with_negative_value()
        {
            Assert.Throws<ApplicationArgumentException>(() => new FileSizeArgument("-1"));
        }
    }
}
