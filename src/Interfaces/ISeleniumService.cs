using OpenQA.Selenium.Chrome;

namespace DesafioTecnicoMP.Interfaces
{
    public interface ISeleniumService
    {
        ICustomChromeDriver CreateChromeDriver();
        ICustomWebDriverWait CreateWebDriverWait(ICustomChromeDriver chromeDriver, int timeout);
        ChromeOptions CreateChromeOptions(params string[] arguments);
        ChromeDriverService CreateChromeDriverService();
    }
}
