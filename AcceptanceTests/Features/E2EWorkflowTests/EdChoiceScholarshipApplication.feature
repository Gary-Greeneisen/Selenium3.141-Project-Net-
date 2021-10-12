Feature: EdChoice Scholarship Application
	Login as scholarship Nominator
	And create a New Scholarship Application
	Update the application to Submitted

	Login as ODE Personnel 
	And search for Submitted Scholarship Applications
	Update the application to Under Reviewed

################################################
#This is a comment
################################################
#Submit New EdChoice Scholarship Application test execution = 1-min
@mytag
Scenario: Submit New EdChoice Scholarship Application Hard Coded Data
	Given my login role "EdChoiceNom1"
	#Given my login role "AutismNom2" 
	#And I select the program "Autism"
	#And I select the program "JPSN"
	And I select the program "EdChoice"
	And I Start a new Scholarship application
	And I Finish a new Scholarship application
	And I Update the Student SSID
	#When I Update the Scholarship Application Status to "Submitted"
	#Then The Application Status is displayed as "Submitted"

Scenario: RepeatTests
	Given my login role "EdChoiceNom1"
	#And I select the program "Autism"
	#And I select the program "JPSN"
	And I select the program "EdChoice"
	Then I Repeat Actions 1 Times

