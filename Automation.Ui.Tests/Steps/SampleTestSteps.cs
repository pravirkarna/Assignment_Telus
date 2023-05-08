using Automation.UI.Accelerators;
using Automation.UI.Accelerators.BaseClasses;
using Automation.UI.Accelerators.Pages;
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
    public class SampleTestSteps : CustomControl
    {

        private DriverHelper _driverHelper;
        private SampleTest _SampleTest;

        public SampleTestSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;


        [Then(@"I should be able to see Dynamic Console Page")]
        [Obsolete]
        public void ThenIShouldBeAbleToSeeDunamicConsolePage()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            Assert.True(sampleTest.verifyDynamicControlsLabel());
        }

        [Then(@"Dynamic Control description should be '(.*)'")]
        [Obsolete]
        public void ThenDynamicControlDescriptionShouldBe(string expected)
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            Assert.True(sampleTest.verifyDescriptions(expected));
        }

        [Then(@"verify A checkbox is present")]
        [Obsolete]
        public void ThenVerifyACheckboxIsPresent()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            Assert.True(sampleTest.isCheckboxPresent());
        }

        [Then(@"user should be able to check the checkbox")]
        public void ThenUserShouldBeAbleToCheckTheCheckbox()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            sampleTest.clickCheckbox();
        }
        [When(@"user clicks on '(.*)' button")]
        public void WhenUserClicksOnRemoveButton(string option)
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            sampleTest.clickAddRemoveButton(option);
        }
        
        [Then(@"checkbox should not get displayed and user should be able to see '(.*)' message")]
        public void WhenCheckboxShouldNotGetDisplayedAndUserShouldBeAbleToSeeSGoneMessage(string message)
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            sampleTest.verifyErrorMessage(message);
        }

        [Then(@"enable disable text area should be disabled by default")]
        public void ThenEnablDisableTextAreaShouldBeDisabledByDefault()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            Assert.False(!sampleTest.isTextAreaEnabled());
        }

        [Then(@"enable disable text area should be enabled")]
        public void ThenEnableDisableTextAreaShouldBeEnabled()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            Assert.True(sampleTest.isTextAreaEnabled());
        }

        [Then(@"user should be abl eto enter some random texts")]
        public void ThenUserShouldBeAblEtoEnterSomeRandomTexts()
        {
            var sampleTest = Retrieve<SampleTest>("sampleTest");
            sampleTest.isTextAreaEditible();
        }



    }
}
