
using Automation.Ui.Accelerators.Constants;
using Automation.UI.Accelerators.BaseClasses;
using Automation.UI.Accelerators.Pages;
using OpenQA.Selenium;

namespace Automation.UI.Accelerators.Pages
{
    /// <summary>
    ///  Represents PageFunction. Inherates from BasePages.
    /// </summary>
    public partial class LoginPage : CustomControls
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public LoginPage()
        {
        }

        private new readonly IWebDriver Driver;
        private static LoginPage _instance;

        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public static LoginPage GetInstance(IWebDriver driver)
        {
            if (_instance == null)
            {
                _instance = new LoginPage(driver);
            }
            return _instance;
        }

        IWebElement txtUserName => GetLocator(Driver, By.Name("user-name"));
        IWebElement txtPassword => GetLocator(Driver, By.Name("password"));
        IWebElement btnLogin => GetLocator(Driver, By.CssSelector("#login-button"));
        IWebElement ProductsPagePageTitle => GetLocator(Driver, By.CssSelector("span[class='title']"));


        public void EnterUserNameAndPassword()
        {
            SendValues(Driver,txtUserName, Constants.Username);
            SendValues(Driver,txtPassword, Constants.Password);            
        }

        public void ClickLogin()
        {
            btnLogin.Click();
            WaitForElement(Driver, ProductsPagePageTitle, true, 20);
        }
        public bool VerifyProductsPagePage()
        {
            WaitForElementVisible(Driver, ProductsPagePageTitle,5);
            return ProductsPagePageTitle.Enabled && ProductsPagePageTitle.Displayed;
        }

        //Method hiding example
        public new ProductsPage NavigateToLoginPage(IWebDriver Driver)
        {
            var applicationUrl = Constants.URL;
            Driver.Navigate().GoToUrl(applicationUrl);

            return new ProductsPage(Driver);
        }


    }



}
