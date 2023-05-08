using Automation.UI.Accelerators.BaseClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation.UI.Accelerators.Pages
{
    public partial class SampleTest : CustomControl
    {
        private IWebDriver Driver;
        private static SampleTest _instance;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public SampleTest()
        {
        }


        public SampleTest(IWebDriver driver) => this.Driver = driver;

        public static SampleTest GetInstance(IWebDriver driver)
        {
            if (_instance == null)
            {
                _instance = new SampleTest(driver);
            }
            return _instance;
        }

        //WebElements

        private IWebElement lblDynamicControl => GetLocator(Driver, By.XPath("//div[@class='example']/h4[contains(text(),'Dynamic Controls')]"));
        private IWebElement checkboxAdd => GetLocator(Driver, By.CssSelector("input[type='checkbox']"));

        private IWebElement description => GetLocator(Driver, By.XPath("//div[@class='example']/p"));


        private IWebElement btnAddRemove => GetLocator(Driver, By.XPath("//button[@onclick='swapCheckbox()']"));
        private IWebElement removeMessage => GetLocator(Driver, By.CssSelector("p[id = 'message']"));

        private IWebElement textArea => GetLocator(Driver, By.CssSelector("form[id='input-example'] input"));


        private IWebElement btnEnableDisable => GetLocator(Driver, By.XPath("//button[@onclick='swapInput()']"));




        //Methods

        public bool verifyDynamicControlsLabel()
        {
            return lblDynamicControl.Displayed;
        }

        public bool verifyDescriptions(string expected)
        {
            return description.Text.Equals(expected);
        }

        public bool isCheckboxPresent()
        {
            return checkboxAdd.Displayed && checkboxAdd.Enabled;
        }
        public bool isTextAreaEnabled()
        {
            return textArea.Displayed && checkboxAdd.Enabled;
        }

        public void isTextAreaEditible()
        {
            textArea.SendKeys(DateTime.Now.ToString());
            textArea.SendKeys(Keys.Tab);
        }

        public void clickCheckbox()
        {
            checkboxAdd.Click();
        }

        public void clickAddRemoveButton(string option)
        {
            if (option.Equals("Remove") || option.Equals("Add"))
            {
                btnAddRemove.Click();
                Thread.Sleep(7000);
                WaitForElement(Driver, removeMessage, true, 20);
            }

            else if (option.Equals("Enable"))
            {
                btnEnableDisable.Click();
                Thread.Sleep(7000);
                WaitForElement(Driver, removeMessage, true, 20);
            }

            else if (option.Equals("Disable"))
            {
                btnEnableDisable.Click();
                Thread.Sleep(7000);
                WaitForElement(Driver, removeMessage, true, 20);
            }


        }

        public bool verifyErrorMessage(string message)
        {
            return removeMessage.Text.Replace("'", "").Equals(message);
        }


    }
}
