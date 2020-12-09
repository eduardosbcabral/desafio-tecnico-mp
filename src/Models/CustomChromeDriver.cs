using DesafioTecnicoMP.Interfaces;
using OpenQA.Selenium.Chrome;

namespace DesafioTecnicoMP.Models
{
    public class CustomChromeDriver : ChromeDriver, ICustomChromeDriver
    {
        public CustomChromeDriver(ChromeDriverService service, ChromeOptions options)
            : base(service, options)
        {

        }
    }
}
