Feature: TestSpecFlowFeature1
	Test and Debug scripts

@mytag
Scenario: Feature1Test1
	Given my login role "AutismNom1"
	#Given my login role "AutismNom2" 
	#Given my login role "ProgramAdmin" 
	And I select the program "Autism"
	#And I select the program "JPSN"
	#And I Search for Applications Status "Started"
	#And I Search for Applications Status "Submitted"
	#And I Select Record 1
	When I Display Test Method 1
	And I Finish a new Scholarship application
	When I Update the Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"

Scenario: Feature1Test2
	Given my login role "AutismNom2"
	Given I login using ODE Personnel role "ProgramSpecialistAutism"
	And I select the program "Autism"
	And I select the program "JPSN"
	And I Search for Scholarship Applications Status "Submitted"
	And I Search for Scholarship Applications First Name "test-14"
	And I Search for Scholarship Applications Last Name "test-8"
	And I Select Scholarship Record 1
	When I Display Test Method 1


Scenario: Feature1Test3
	Given I login using ODE Personnel role "ProgramSpecialistAutism"
	And I select the program "Autism"
	#And I select the program "JPSN"
	And I Search for Scholarship Applications Status "Submitted"
	And I Select Scholarship Record 1
	#When I Update the Scholarship Application Status to "Under Review"
	#When I Update the Scholarship Application Status to "Review Completed"
	#Then The Application Status is displayed as "Eligible"
	When I Display Test Method 1


