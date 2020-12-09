using DesafioTecnicoMP.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioTecnicoMP.Models
{
    public class CustomWebDriverWait : WebDriverWait, ICustomWebDriverWait
    {
        public CustomWebDriverWait(IWebDriver driver, TimeSpan timeout)
            : base(driver, timeout)
        {
        }
    }
}
