namespace DesafioTecnicoMP.Interfaces
{
    public interface ICrawlerService
    {
        ICustomChromeDriver Driver { get; }
        ICustomWebDriverWait Wait { get; }

        ICrawlerService Setup();
        ICrawlerService GoToUrl(string url);
        string GetTextContentFromElement(string cssSelector);
        ICrawlerService SetTextToElement(string text, string cssSelector);
        ICrawlerService CleanElement(string cssSelector);
        void Quit();
    }
}
