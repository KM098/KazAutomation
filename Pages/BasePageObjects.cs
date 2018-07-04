using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Pages.Interface;

namespace Pages
{
    public class BasePageObjects : IBasePageObjects
    {
        public IWebDriver Driver { get; set; }
        public string PageTitle { get; set; }
        public string PageUrl { get; set; }
        public WebDriverWait Wait { get; set; }
    }
}