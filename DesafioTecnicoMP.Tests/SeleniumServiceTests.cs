using DesafioTecnicoMP.Services;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class SeleniumServiceTests
    {
        [Fact]
        public void Should_create_chrome_options()
        {
            var seleniumService = new SeleniumService();
            var chromeOptions = seleniumService.CreateChromeOptions();
            Assert.NotNull(chromeOptions);
        }

        [Fact]
        public void Should_create_chrome_driver_service()
        {
            var seleniumService = new SeleniumService();
            var chromeOptions = seleniumService.CreateChromeDriverService();
            Assert.NotNull(chromeOptions);
        }
    }
}
