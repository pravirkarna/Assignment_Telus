Feature: SampleTest

This feature is to test all the functionality of SwagLabs.com


Background:
	Given I navigate to application
	When user enters a valid username and password
	Then user should be able to login successfully
	
@smoke @regression
Scenario: Test-1 Verify login functionality
	Then user is redirected to 'ProductsPage' page

@regression
Scenario: Test-2 Verify Buying functionality - 2 Items
	When user adds '3' items to Cart
	Then '3' items should be added to Cart
	When I remove '1' item from the cart
	Then '1' Item should get removed succesfully
	When I click on checkout and fill all checkout details
	Then I should be routed to checkout overview page
	When I check the overview details and click on Finish
	Then order should get placed and user should see success message as 'Thank you for your order!'

@regression
Scenario: Test-3 Buying Items within a range of $30-$60
	When user add items to Cart within a range of '30' and '60'
	Then all items should get addedd to cart
	When I click on checkout and fill all checkout details
	Then I should be routed to checkout overview page
	When I check the overview details and click on Finish
	Then order should get placed and user should see success message as 'Thank you for your order!'
	

