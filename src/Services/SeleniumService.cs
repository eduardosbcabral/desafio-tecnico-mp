using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Models;
using OpenQA.Selenium.Chrome;
using System;

namespace DesafioTecnicoMP.Services
{
    public class SeleniumService : ISeleniumService
    {
        public SeleniumService()
        {

        }

        public ICustomChromeDriver CreateChromeDriver()
        {
            return new CustomChromeDriver(CreateChromeDriverService(), CreateChromeOptions());
        }

        public ICustomWebDriverWait CreateWebDriverWait(ICustomChromeDriver chromeDriver, int timeout)
        {
            return new CustomWebDriverWait(chromeDriver, TimeSpan.FromSeconds(timeout));
        }

        public ChromeOptions CreateChromeOptions(params string[] arguments)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(arguments);
            chromeOptions.AddArgument("headless");
            return chromeOptions;
        }

        public ChromeDriverService CreateChromeDriverService()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            return driverService;
        }
    }
}
