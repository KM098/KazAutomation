using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using Methods;
using Methods.Interface;
using Pages.Interface;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private IWebDriver _driver;
        public HomePage Homepage;
        private IPopUp _iPopUp;
        private IBasePageObjects _iBasePageObjects;


        [SetUp]
        public void TestInitialize()
        {
            _driver = InitializeDriver();
            InitializePageMethods();
        }

        [Test]
        public void OpneHomePage()
        {
            Homepage.GoTo("www.lowes.ca");
            Assert.IsTrue(Homepage.IsAt(), "Homepage doesn't open");
            Assert.IsTrue(Homepage.IsEmailPopUpDisplayed(), "Eamil pop up doesn't open");
        }

        [Test]
        public void CloseEmailPopBox()
        {
            Homepage.GoTo("https://www.lowes.ca");
            Homepage.CloseEmailPopUp();
            Assert.IsFalse(Homepage.IsEmailPopUpDisplayed(), "Eamil pop up is not closed");
        }

        [TearDown]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        public void InitializePageMethods()
        {
            _iPopUp = new PopUp(_driver);
            _iBasePageObjects = new BasePageObjects();
            _iBasePageObjects.Driver = _driver;
            _iBasePageObjects.PageTitle = "Lowe's Canada: Home Improvement, Appliances, Tools, Bathroom, Kitchen";
            _iBasePageObjects.PageUrl = "www.lowes.ca";
            _iBasePageObjects.Wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            Homepage = new HomePage(_iPopUp, _iBasePageObjects);
        }

        public IWebDriver InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            
            using (_driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {                
                _driver.Manage().Window.Maximize();
                _driver.Manage().Cookies.DeleteAllCookies();
            }
            
            return _driver;
        }
    }
}

