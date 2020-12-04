﻿using DesafioTecnicoMP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class ArgumentsFactoryTests
    {
        private const string FILE_SIZE_ARGUMENT = "-f";
        private const string BUFFER_LENGTH_ARGUMENT = "-b";
        private const string PATH_ARGUMENT = "-p";

        private string[] args = new string[] { FILE_SIZE_ARGUMENT, "5", BUFFER_LENGTH_ARGUMENT, "10", PATH_ARGUMENT, @"D:\dev" };

        [Fact]
        public void Should_get_file_size_argument_correctly()
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);
            var argument = (FileSizeArgument)argumentsFactory.GetArgument(FILE_SIZE_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(5242880L, argument.GetValue());
        }

        [Fact]
        public void Should_get_buffer_length_argument_correctly()
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);
            var argument = (BufferLengthArgument)argumentsFactory.GetArgument(BUFFER_LENGTH_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(10485760L, argument.GetValue());
        }

        [Fact]
        public void Should_get_path_argument_correctly()
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);
            var argument = (PathArgument)argumentsFactory.GetArgument(PATH_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(@"D:\dev", argument.GetValue());
        }
    }
}