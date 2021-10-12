Feature: Autism Scholarship Application
	Login as scholarship Nominator
	And create a New Scholarship Application
	Update the application to Submitted

	Login as ODE Personnel 
	And search for Submitted Scholarship Applications
	Update the application to Under Reviewed

################################################
#This is a comment
################################################
#Submit New Autism Scholarship Application test execution = 3-min
@mytag
Scenario: Submit New Autism Scholarship Application Hard Coded Data
	Given my login role "AutismNom1"
	#Given my login role "AutismNom2" 
	And I select the program "Autism"
	#And I select the program "JPSN"
	And I Start a new Scholarship application
	And I Finish a new Scholarship application
	When I Update the Scholarship Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"

#Submit New Autism Scholarship Application test execution = 3-min
@mytag
Scenario: Submit New Autism Scholarship Application XML Data
	Given my login role "AutismNom1"
	#Given my login role "AutismNom2" 
	And I select the program "Autism"
	#And I select the program "JPSN"
	 And I Start a new Scholarship application
	| Filename                   |
	| AutismScholarshipApplication.xml |
	And I Finish a new Scholarship application
	When I Update the Scholarship Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"

#Approve New Autism Scholarship Application test execution = 1-min
@mytag
Scenario: Approve New Autism Application Hard Coded Data
	#Given my login role "AutismNom2"
	Given I login using ODE Personnel role "ProgramSpecialistAutism"
	And I select the program "Autism"
	#And I select the program "JPSN"
	And I Search for Scholarship Applications Status "Submitted"
	And I Select Scholarship Record 1
	When I Update the Scholarship Application Status to "Under Review"
	When I Update the Scholarship Application Status to "Review Completed"
	Then The Application Status is displayed as "Eligible"

