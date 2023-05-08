Feature: SampleTest

This feature is to test all the functionality of Herokuapp.com


Background: 
	Given I navigate to application
	Then I should be able to see Dynamic Console Page
	
@smoke
Scenario: Verify Description Text at Dynamic Controls Page
	Then Dynamic Control description should be 'This example demonstrates when elements (e.g., checkbox, input field, etc.) are changed asynchronously.'

@regression
Scenario: Verify Checkbox at Dynamic Controls Page
	Then verify A checkbox is present
	And user should be able to check the checkbox

@regression
Scenario: Verify Add Remove button functionality at Dynamic Controls Page
	When user clicks on 'Remove' button
	Then checkbox should not get displayed and user should be able to see 'Its gone!' message 
	When user clicks on 'Add' button
	Then checkbox should not get displayed and user should be able to see 'Its back!' message 
	And verify A checkbox is present

@regression
Scenario: Verify Enable Disable functionality at Dynamic Controls Page
    Then enable disable text area should be disabled by default
	When user clicks on 'Enable' button
	Then enable disable text area should be enabled
	And user should be abl eto enter some random texts
	When user clicks on 'Disable' button
	Then checkbox should not get displayed and user should be able to see 'It's disabled!' message 
	Then enable disable text area should be disabled by default