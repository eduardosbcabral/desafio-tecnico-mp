using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Services;
using Moq;
using Xunit;

namespace DesafioTecnicoMP.Tests
{
    public class CrawlerServiceTests
    {
        [Fact]
        public void Should_setup_correctly()
        {
            // Impossível mockar as classes do Selenium...
            var seleniumServiceMock = new Mock<ISeleniumService>();

            var chromeDriverMock = new Mock<ICustomChromeDriver>();
            var chromeDriverMockWait = new Mock<ICustomWebDriverWait>();
            
            seleniumServiceMock.Setup(x => x.CreateChromeDriver())
                .Returns(chromeDriverMock.Object);
            seleniumServiceMock.Setup(x => x.CreateWebDriverWait(It.IsAny<ICustomChromeDriver>(), It.IsAny<int>()))
                .Returns(chromeDriverMockWait.Object);

            var crawlerService = new CrawlerService(seleniumServiceMock.Object);
            crawlerService.Setup();
            Assert.NotNull(crawlerService.Driver);
            Assert.NotNull(crawlerService.Wait);
            crawlerService.Quit();
        }
    }
}
