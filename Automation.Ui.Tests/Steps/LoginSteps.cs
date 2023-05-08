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
    public class LoginSteps : CustomControl
    {
        private DriverHelper _driverHelper;
        private IWebDriver _driver;

        public LoginSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
      

        [Given(@"I navigate to application")]
        [Obsolete]
        public void GivenINavigateToApplication()
        {
            var sampleTest = LoginPage.GetInstance(_driverHelper.Driver).NavigateToLoginPage(_driverHelper.Driver);
            Save("sampleTest", sampleTest);
        }

       

    }
}
