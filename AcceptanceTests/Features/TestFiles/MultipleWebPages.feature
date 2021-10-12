Feature: MultipleWebPages
	Display multiple web pages
	using PageObject LoginPage
	And a feature datatable
	Use the browser specified in the App.conf file

@MultipleWebPagesLogin
Scenario Outline: TableDrivenProgram
	Given I navigate to "<WebPage>"
	And I verify page "<PageText>"
	Then I Close The Web Page

Examples: 
| WebPage							| PageText    |
| https://www.google.com/			| Gmail       |
| https://www.yahoo.com/			| Yahoo       | 
| https://www.microsoft.com/en-us/  | Microsoft	  | 



