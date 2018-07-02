using OpenQA.Selenium;
using Pages.Interface;

namespace Pages
{
    public abstract class BaseSetUp
    {
        private readonly IBasePageObjects _basePageObjects;

        public BaseSetUp(IBasePageObjects basePageObjects)
        {
            _basePageObjects = basePageObjects;
        }

        public bool IsDisplayed(IWebElement element) => element == null ? false : element.Displayed;

        public void GoTo(string paramUrl) => _basePageObjects.Driver.Navigate().GoToUrl(paramUrl);

        public virtual bool IsAt() => GetTitle() == _basePageObjects.PageTitle;

        public string GetTitle() => _basePageObjects.Wait.Until<string>((d) => { return _basePageObjects.Driver.Title; });        

        public string GetH1Text() => _basePageObjects.Driver.FindElement(By.TagName("h1")).Text;

        public void EnterText(IWebElement textBox, string text, bool clearBeforeEntering = false)
        {
            try
            {
                if (clearBeforeEntering)
                    textBox.Clear();

                textBox.SendKeys(text);
            }
            catch (System.Exception ex)
            {
                throw new System.ApplicationException("Unable to enter text \"" + text + "\" in the textbox: " + ex.Message);
            }
        }
    }
}
