using DesafioTecnicoMP.Services;
using System;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class WriteBufferTests
    {
        [Fact]
        public void Should_write_buffer_until_end()
        {
            var str = "te";
            var writeBuffer = new WriteBuffer(2);
            var buffer = writeBuffer.StringInput(str)
                .WriteUntilEnd()
                .Buffer();

            Assert.Equal(new byte[] { 116, 101 }, buffer);
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_trying_to_write_buffer_with_empty_str()
        {
            var writeBuffer = new WriteBuffer(2);

            Assert.Throws<ArgumentNullException>(() => writeBuffer
                .StringInput("")
                .WriteUntilEnd());
        }

        [Fact]
        public void Should_throw_ArgumentNullException_when_trying_to_write_buffer_with_null_str()
        {
            var writeBuffer = new WriteBuffer(2);

            Assert.Throws<ArgumentNullException>(() => writeBuffer
                .StringInput(null)
                .WriteUntilEnd());
        }

        [Fact]
        public void Should_clear_buffer()
        {
            var str = "te";
            var writeBuffer = new WriteBuffer(2);
            var buffer = writeBuffer.StringInput(str)
                .WriteUntilEnd()
                .Clear()
                .Buffer();

            Assert.Equal(new byte[] { 0, 0 }, buffer);
        }
    }
}
