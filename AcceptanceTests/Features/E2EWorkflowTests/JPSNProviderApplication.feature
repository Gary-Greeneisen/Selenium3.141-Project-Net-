Feature: JPSN Provider Application
	Login as scholarship Provider
	And create a New JSPN Application
	Update the application to Submitted

	Login as ODE Personnel 
	And search for Submitted Applications
	Update the application to Reviewed and Approved

################################################
#This is a comment
################################################

#Submit New JPSN Application test execution = 4-min
@mytag
Scenario: Submit New JPSN Application Table Data
	#Given my login role "JPSNNom1"
	Given my login role "AutismNom2" 
	#And I select the program "Autism"
	And I select the program "JPSN"
	And I Start a new Provider application
	| Personnel Role									 | Services							   | Staff				   |
	| stautnom096263,scholar,12/31/2010,Nominator-JPSN   | Adapted Physical Education Services | Lynn,Cosmo,01/01/2001 |
	|													 | Aide Services					   | 					   |
	And I Finish a new Provider application
	When I Update the Provider Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"


#Submit Approve New JPSN Application test execution = 1-min
@mytag
Scenario: Approve New JSPN Application
	Given I login using ODE Personnel role "ProgramAdmin"
	#And I select the program "Autism"
	And I select the program "JPSN"
	And I Search for Provider Applications Status "Submitted"
	And I Select Provider Record 1
	When I Update the Provider Application Status to "Under Review"
	When I Update the Provider Application Status to "Approved"
	Then The Application Status is displayed as "Approved"

