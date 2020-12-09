using DesafioTecnicoMP.Services;
using System.Text.RegularExpressions;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class FileServiceTests
    {
        [Fact]
        public void Should_interpolate_filename_correctly()
        {
            var fileService = new FileService(@"D:\dev", 0);
            var pattern = @"^[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{6}-desafio\.txt";
            var match = Regex.Match(fileService.FileName, pattern);
            Assert.True(match.Success);
        }

        [Fact]
        public void Should_combine_full_path_correctly()
        {
            var fileService = new FileService(@"D:\dev", 0);
            var pattern = @"^D:\\dev\\[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{6}-desafio\.txt";
            var match = Regex.Match(fileService.FullPath, pattern);
            Assert.True(match.Success);
        }
    }
}
