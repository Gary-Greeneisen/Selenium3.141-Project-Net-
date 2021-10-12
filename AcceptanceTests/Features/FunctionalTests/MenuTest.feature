Feature: MenuTest
	Test each Parent and Child submenus

Scenario: MenuTest1
	Given I login as role "JPSNAdmin"
	#Given I login as role "EdChoiceNom1"
	And I Click on link "Scholarship"
	And I select the program "EdChoice"
	When I test all menus

