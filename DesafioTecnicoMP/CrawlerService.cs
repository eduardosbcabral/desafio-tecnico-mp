using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioTecnicoMP
{
    public class CrawlerService
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        private string _url;

        private const int timeout = 10;

        public CrawlerService()
        {
            Setup();
        }

        public CrawlerService Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            _driver = new ChromeDriver(driverService, chromeOptions);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            return this;
        }

        public CrawlerService GoToUrl(string url)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);
                _url = url;
            } 
            catch(WebDriverException)
            {
                throw new CrawlerException(CrawlerErrors.Random());
            }

            return this;
        }

        public string GetTextContentFromElement(string cssSelector)
        {
            var text = string.Empty;

            try
            {
                _wait.Until(driver => driver.FindElement(By.CssSelector(cssSelector)).Displayed);

                var element = _driver.FindElement(By.CssSelector(cssSelector));
                text = element.GetAttribute("textContent");
            }
            catch(NoSuchElementException)
            {
                throw new CrawlerException(CrawlerErrors.Random());
            }

            return text;
        }

        public CrawlerService SetTextToElement(string text, string cssSelector)
        {
            try
            {
                _wait.Until(driver => driver.FindElement(By.CssSelector(cssSelector)).Displayed);

                var element = _driver.FindElement(By.CssSelector(cssSelector));
                element.SendKeys(text);
            }
            catch (NoSuchElementException)
            {
                throw new CrawlerException(CrawlerErrors.Random());
            }

            return this;
        }

        public CrawlerService CleanElement(string cssSelector)
        {
            return SetTextToElement(string.Empty, cssSelector);
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
