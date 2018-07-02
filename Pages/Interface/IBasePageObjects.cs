using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.Interface
{
    public interface IBasePageObjects
    {
        IWebDriver Driver { get; set; }
        string PageTitle { get; set; }
        string PageUrl { get; set; }
        WebDriverWait Wait { get; set; }
    }
}
