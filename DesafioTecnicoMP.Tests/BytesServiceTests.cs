using DesafioTecnicoMP.Services;
using System;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class BytesServiceTests
    {
        [Fact]
        public void Should_count_from_string_correctly()
        {
            Assert.Equal(4, BytesService.CountFromString("test"));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_counting_from_string_and_argument_is_null()
        {
            Assert.Throws<ArgumentException>(() => BytesService.CountFromString(null));
        }

        [Fact]
        public void Should_return_byte_array_from_string_correctly()
        {
            Assert.Equal(new byte[4] { 116, 101, 115, 116 }, BytesService.StringToBytes("test"));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_converting_string_to_bytes_and_argument_is_null()
        {
            Assert.Throws<ArgumentException>(() => BytesService.StringToBytes(null));
        }

        [Fact]
        public void Should_convert_megabytes_to_bytes_correctly()
        {
            Assert.Equal(10485760, BytesService.ConvertMegabytesToBytes(10L));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_converting_megabytes_to_bytes_and_argument_is_zero()
        {
            Assert.Throws<ArgumentException>(() => BytesService.ConvertMegabytesToBytes(0));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_converting_megabytes_to_bytes_and_argument_is_lesser_than_zero()
        {
            Assert.Throws<ArgumentException>(() => BytesService.ConvertMegabytesToBytes(-1));
        }

        [Fact]
        public void Should_convert_bytes_to_megabytes_correctly()
        {
            Assert.Equal(10L, BytesService.ConvertBytesToMegabytes(10485760));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_converting_bytes_to_megabytes_and_argument_is_zero()
        {
            Assert.Throws<ArgumentException>(() => BytesService.ConvertBytesToMegabytes(0));
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_converting_bytes_to_megabytes_and_argument_is_lesser_than_zero()
        {
            Assert.Throws<ArgumentException>(() => BytesService.ConvertBytesToMegabytes(-1));
        }
    }
}
