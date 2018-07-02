using Methods.Interface;
using OpenQA.Selenium;
using Pages.Interface;

namespace Pages
{
    public class HomePage : BaseSetUp
    {
        private readonly IPopUp _popUp;
        public HomePage(IPopUp popUp, IBasePageObjects basePageObjects) : base(basePageObjects)
        {
            _popUp = popUp;
        }

        public void ClosePopBox(IWebElement closeButton) => closeButton.Click();

        public bool IsEmailPopUpDisplayed() => IsDisplayed(_popUp.EmailPopUp);
        public void CloseEmailPopUp() => ClosePopBox(_popUp.EmailPopUpCloseButton);
    }
}
