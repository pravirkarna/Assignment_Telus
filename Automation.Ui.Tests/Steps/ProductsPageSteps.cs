using Automation.UI.Accelerators;
using Automation.UI.Accelerators.BaseClasses;
using Automation.UI.Accelerators.Pages;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace Automation.Ui.Tests.Steps
{
    [Binding]
    public class ProductsPageSteps : CustomControls
    {

        private DriverHelper _driverHelper;
        private ProductsPage _ProductsPage;

        public ProductsPageSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;


        [Then(@"user is redirected to '(.*)' page")]
        public void GivenUserIsRedirectedToPage(string productsPage)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            Assert.True(ProductsPage.isShoppingCartDisplayed());
        }

        [When(@"user adds '(.*)' items to Cart")]
        public void WhenUserAddsItemsToCart(int itemCount)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            ProductsPage.addItemsToCart(itemCount);
        }

        [Then(@"'(.*)' items should be added to Cart")]
        public void ThenItemsShouldBeAddedToCart(int items)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            ProductsPage.ClickOnCart();
            int result = ProductsPage.countCartItems();
            Assert.AreEqual(result, items,"Cart Items is not equal to selected items");
            Save("result", result);
        }

        [Then(@"all items should get addedd to cart")]
        public void ThenAllItemsShouldGetAddeddToCart()
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            ProductsPage.ClickOnCart();
            int finalCount = ProductsPage.countCartItems();            
            Save("finalCount", finalCount);
        }


        [When(@"I remove '(.*)' item from the cart")]
        public void WhenIRemoveItemFromTheCart(int value)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            int count = ProductsPage.RemoveCartItems(value);
            Save("count", count);
        }

        [Then(@"'(.*)' Item should get removed succesfully")]
        public void ThenItemShouldGetRemovedSuccesfully(int value)
        {
            var selectedItem = Retrieve<int>("result");
            var finalCount   = Retrieve<int>("count");
            Assert.AreEqual(finalCount, selectedItem - value, "Cart Items is not removed");
            Save("finalCount", finalCount);
        }

        [When(@"I click on checkout and fill all checkout details")]
        public void WhenIClickOnCheckoutAndFillAllCheckoutDetails()
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            ProductsPage.ClickOnCheckout();
            ProductsPage.EnterCheckoutDetails();
            ProductsPage.ClickOnContinue();
        }

        [Then(@"I should be routed to checkout overview page")]
        public void ThenIShouldBeroutedToCheckoutOverviewPage()
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");           
            Assert.True(ProductsPage.IsCheckoutOverviewDisplayed());            
        }

        [When(@"I check the overview details and click on Finish")]
        public void WhenICheckTheOverviewDetailsAndClickOnFinish()
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            var finalCount = Retrieve<int>("finalCount");           
            Assert.AreEqual(finalCount, ProductsPage.countCartItems());
            ProductsPage.ClickOnFinish();
        }

        [Then(@"order should get placed and user should see success message as '(.*)'")]
        public void ThenOrderShouldGetPlacedAndUserShouldSeeSuccessMessageAs(string message)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            Assert.True(ProductsPage.VerifyOrderPlacedSuccessMessage(message));
        }

        [When(@"user add items to Cart within a range of '(.*)' and '(.*)'")]
        public void WhenUserAddItemsToCartWithinARangeOfAnd(double start, double end)
        {
            var ProductsPage = Retrieve<ProductsPage>("ProductsPage");
            ProductsPage.AddItemsWithinPriceRange(start,end);            
        }





    }
}
