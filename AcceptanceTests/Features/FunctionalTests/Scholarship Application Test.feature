Feature: Scholarship Application Test
	Test and Debug scripts

@mytag
Scenario: Scholarship Application Test
	Given my login role "AutismNom1"
	#Given my login role "AutismNom2" 
	#Given my login role "ProgramAdmin" 
	#And I select the program "Autism"
	And I select the program "JPSN"
	And I Search for Applications Status "Started"
	#And I Search for Applications Status "Submitted"
	And I Select Record 1
	When I Display Test Method 1
	When I Update the Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"


