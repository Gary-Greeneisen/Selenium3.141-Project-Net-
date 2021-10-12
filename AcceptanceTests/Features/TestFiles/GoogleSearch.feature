Feature: Google Search Example
	Test example of Specflow and Selenium Webdriver


@GoogleSearchFeature
Scenario: Google Search Feature
	Given I Open a browser to "www.google.com"
	And I search for "Books"
	When I click on the first link
	#Then the number of page images are 10
	Then the number of page images are 163

