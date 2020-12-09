namespace DesafioTecnicoMP.Interfaces
{
    public interface ICrawlerService
    {
        ICustomChromeDriver Driver { get; }
        ICustomWebDriverWait Wait { get; }

        CrawlerService Setup();
        CrawlerService GoToUrl(string url);
        string GetTextContentFromElement(string cssSelector);
        CrawlerService SetTextToElement(string text, string cssSelector);
        CrawlerService CleanElement(string cssSelector);
        void Quit();
    }
}
