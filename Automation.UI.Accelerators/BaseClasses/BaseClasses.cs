using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Xml;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Text;
using Automation.Ui.Accelerators.Constants;
using Automation.UI.Accelerators.HelperClasses;

namespace Automation.UI.Accelerators.BaseClasses
{
    /// <summary>
    /// This is the Super class for all pages
    /// </summary>
    /// 
    public abstract class BasePages
    {
        /// <summary>
        /// Get the browser configuration details
        /// </summary>
        public Dictionary<string, string> BrowserConfig = Helper.BrowserConfig;

        /// <summary>
        /// Gets or Sets Driver
        /// </summary>
        public RemoteWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or Sets Test Data as XMLNode
        /// </summary>
        public XmlNode TestDataNode { get; set; }

        /// <summary>
        /// Gets or Sets Reporter
        /// </summary>

 
        public BasePages()
        {

        }

        public BasePages(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public BasePages(XmlNode testNode)
        {
            TestDataNode = testNode;
        }

        public BasePages(RemoteWebDriver driver, XmlNode testNode)
        {
            Driver = driver;
            TestDataNode = testNode;
        }

        public static void tearDown(IWebDriver driver)
        {
            driver.Quit();
        }

    }
}

