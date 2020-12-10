using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using DesafioTecnicoMP.Services;
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
            var argumentsFactory = new ArgumentsFactory(args, ArgumentsConstants.FILE_SIZE_ARGUMENT, ArgumentsConstants.BUFFER_LENGTH_ARGUMENT, ArgumentsConstants.PATH_ARGUMENT);
            var argument = argumentsFactory.CreateArgument<FileSizeArgument>(FILE_SIZE_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(5242880L, argument.GetValue());
        }

        [Fact]
        public void Should_get_buffer_length_argument_correctly()
        {
            var argumentsFactory = new ArgumentsFactory(args, ArgumentsConstants.FILE_SIZE_ARGUMENT, ArgumentsConstants.BUFFER_LENGTH_ARGUMENT, ArgumentsConstants.PATH_ARGUMENT);
            var argument = argumentsFactory.CreateArgument<BufferLengthArgument>(BUFFER_LENGTH_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(10485760L, argument.GetValue());
        }

        [Fact]
        public void Should_get_path_argument_correctly()
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);
            var argument = argumentsFactory.CreateArgument<PathArgument>(PATH_ARGUMENT);
            Assert.NotNull(argument);
            Assert.Equal(@"D:\dev", argument.GetValue());
        }

        [Fact]
        public void Should_throw_ApplicationArgumentException_when_geting_invalid_argument()
        {
            var argumentsFactory = new ArgumentsFactory(args, ArgumentsConstants.FILE_SIZE_ARGUMENT, ArgumentsConstants.BUFFER_LENGTH_ARGUMENT, ArgumentsConstants.PATH_ARGUMENT);
            Assert.Throws<ApplicationArgumentException>(() => argumentsFactory.CreateArgument<PathArgument>("wrong"));
        }
    }
}
