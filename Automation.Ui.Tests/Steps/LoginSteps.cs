using Automation.UI.Accelerators;
using Automation.UI.Accelerators.BaseClasses;
using Automation.UI.Accelerators.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.Ui.Tests.Steps
{

    [Binding]
    public class LoginSteps : CustomControls
    {
        private DriverHelper _driverHelper;
        private IWebDriver _driver;

        public LoginSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        public LoginPage login = new LoginPage();


        [Given(@"I navigate to application")]
        [Obsolete]
        public void GivenINavigateToApplication()
        {
            var ProductsPage = LoginPage.GetInstance(_driverHelper.Driver).NavigateToLoginPage(_driverHelper.Driver);
            Save("ProductsPage", ProductsPage);
        }

        [When(@"user enters a valid username and password")]
        public void WhenUserEntersAValidUsernameAndPassword()
        {
            LoginPage.GetInstance(_driverHelper.Driver).EnterUserNameAndPassword();
            LoginPage.GetInstance(_driverHelper.Driver).ClickLogin();
        }

        [Then(@"user should be able to login successfully")]
        public void ThenUserShouldBeAbleToLoginSuccessfully()
        {
            Assert.True(LoginPage.GetInstance(_driverHelper.Driver).VerifyProductsPagePage());
        }



    }
}
