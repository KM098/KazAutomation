using OpenQA.Selenium;

namespace Methods.Interface
{
    public interface IPopUp
    {
        IWebElement EmailPopUp { get; }
        IWebElement EmailPopUpCloseButton { get; }
        void ClosePopBox(IWebElement closeButton);
    }
}
