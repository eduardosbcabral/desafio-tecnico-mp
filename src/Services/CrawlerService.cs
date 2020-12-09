using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Interfaces;
using OpenQA.Selenium;

namespace DesafioTecnicoMP.Services
{
    public class CrawlerService : ICrawlerService
    {
        public ICustomChromeDriver Driver { get; private set; }
        public ICustomWebDriverWait Wait { get; private set; }

        private string _url;

        private const int timeout = 10;

        private readonly ISeleniumService _seleniumService;

        public CrawlerService(ISeleniumService seleniumService)
        {
            _seleniumService = seleniumService;
        }

        public ICrawlerService Setup()
        {
            Driver = _seleniumService.CreateChromeDriver();
            Wait = _seleniumService.CreateWebDriverWait(Driver, timeout);

            return this;
        }

        public ICrawlerService GoToUrl(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
                _url = url;
            } 
            catch(WebDriverException)
            {
                throw new CrawlerException(Errors.Random());
            }

            return this;
        }

        public string GetTextContentFromElement(string cssSelector)
        {
            var text = string.Empty;

            try
            {
                Wait.Until(driver => driver.FindElement(By.CssSelector(cssSelector)).Displayed);

                var element = Driver.FindElement(By.CssSelector(cssSelector));
                text = element.GetAttribute("textContent");
            }
            catch(NoSuchElementException)
            {
                throw new CrawlerException(Errors.Random());
            }

            return text;
        }

        public ICrawlerService SetTextToElement(string text, string cssSelector)
        {
            try
            {
                Wait.Until(driver => driver.FindElement(By.CssSelector(cssSelector)).Displayed);

                var element = Driver.FindElement(By.CssSelector(cssSelector));
                element.SendKeys(text);
            }
            catch (NoSuchElementException)
            {
                throw new CrawlerException(Errors.Random());
            }

            return this;
        }

        public ICrawlerService CleanElement(string cssSelector)
        {
            return SetTextToElement(string.Empty, cssSelector);
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
