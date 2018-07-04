using OpenQA.Selenium;

using Methods.Interface;

namespace Methods
{
    public class PopUp : IPopUp
    {
        private IWebDriver _driver;
        public PopUp(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement EmailPopUp => _driver.FindElement(By.ClassName("signup-offer-form"));
        public IWebElement EmailPopUpCloseButton => _driver.FindElement(By.ClassName("mfp-close"));
        public void ClosePopBox(IWebElement closeButton) => closeButton.Click();
    }
}

