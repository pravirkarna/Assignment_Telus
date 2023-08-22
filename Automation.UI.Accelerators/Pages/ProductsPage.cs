using Automation.Ui.Accelerators.Constants;
using Automation.UI.Accelerators.BaseClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Automation.UI.Accelerators.Pages
{
    public partial class ProductsPage : CustomControls
    {
        private IWebDriver Driver;
        private static ProductsPage _instance;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ProductsPage()
        {
        }


        public ProductsPage(IWebDriver driver) => this.Driver = driver;

        public static ProductsPage GetInstance(IWebDriver driver)
        {
            if (_instance == null)
            {
                _instance = new ProductsPage(driver);
            }
            return _instance;
        }

        //WebElements

        private IWebElement linkShoppingCart => GetLocator(Driver, By.CssSelector(" a[class='shopping_cart_link']"));

        private IWebElement addToCartPageTitle => GetLocator(Driver, By.XPath(" //span[text()='Your Cart']"));

        private IWebElement checkoutInformationPageTitle => GetLocator(Driver, By.XPath(" //span[text()='Checkout: Your Information']"));

        private IWebElement checkoutOverviewPageTitle => GetLocator(Driver, By.XPath(" //span[text()='Checkout: Overview']"));

        private IWebElement checkoutCompletePageTitle => GetLocator(Driver, By.XPath(" //span[text()='Checkout: Complete!']"));
        private IWebElement checkoutButton => GetLocator(Driver, By.Name("checkout"));

        private IWebElement thankYouText => GetLocator(Driver, By.CssSelector("  h2[class='complete-header']"));

        private IWebElement firstName => GetLocator(Driver, By.Name("firstName"));

        private IWebElement lastName => GetLocator(Driver, By.Name("lastName"));

        private IWebElement postal => GetLocator(Driver, By.Name("postalCode"));

        private IWebElement continueButton => GetLocator(Driver, By.Name("continue"));

        private IWebElement finishButton => GetLocator(Driver, By.Name("finish"));

        private IList<IWebElement> inventoryItems => GetWebLocators(Driver, By.CssSelector(" div[class='inventory_list'] div[class='inventory_item']"));

        private IList<IWebElement> cartItems => GetWebLocators(Driver, By.CssSelector("div[class='cart_item']"));



        //Methods

        public int countCartItems() => cartItems.Count;

        public int RemoveCartItems(int number)
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 3);

            cartItems[value].FindElement(By.CssSelector(" button")).Click();

            return countCartItems();
        }


        public void ClickOnCart()
        {
            linkShoppingCart.Click();
            WaitForElement(Driver, addToCartPageTitle, true, 20);
        }

        public void ClickOnCheckout()
        {
            checkoutButton.Click();
            WaitForElement(Driver, checkoutInformationPageTitle, true, 20);
        }

        public void EnterCheckoutDetails()
        {
            firstName.SendKeys(Constants.FirstName);
            lastName.SendKeys(Constants.LastName);
            postal.SendKeys(Constants.Postal);
        }

        public void ClickOnContinue()
        {
            continueButton.Click();
            WaitForElement(Driver, checkoutOverviewPageTitle, true, 20);
        }

        public void ClickOnFinish()
        {
            finishButton.Click();
            WaitForElement(Driver, checkoutCompletePageTitle, true, 20);
        }

        public bool VerifyOrderPlacedSuccessMessage(string message) => thankYouText.Text.Equals(message);

        public bool isShoppingCartDisplayed()
        {
            return linkShoppingCart.Displayed && linkShoppingCart.Enabled;
        }

        public bool IsCheckoutOverviewDisplayed() => IsElementVisible(checkoutOverviewPageTitle);

        public void AddItemsWithinPriceRange(double start, double end)
        {
            double finalPrice = 0.00;

            foreach (var item in inventoryItems)
            {

                var itemPrice = ConvertStringToDouble(item.FindElement(By.CssSelector("[class='inventory_item_price']")).Text);

                finalPrice = finalPrice + itemPrice;

                if (finalPrice > end)
                    break;

                else
                {
                    item.FindElement(By.CssSelector(" button")).Click();
                }

            }
            
        }

        public void addItemsToCart(int number)
        {
            int count = 0;

            foreach (var item in inventoryItems)
            {
                if (number == count)
                    break;

                else
                {
                    if (item.FindElement(By.CssSelector(" button")).Text.Equals("Remove"))
                        item.FindElement(By.CssSelector(" button")).Click();

                    item.FindElement(By.CssSelector(" button")).Click();

                }

                count++;
            }
        }

    }
}
