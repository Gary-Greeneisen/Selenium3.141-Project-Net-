Feature: JPSN Scholarship Application
	Login as scholarship Nominator
	And create a New Scholarship Application
	Update the application to Submitted

	Login as ODE Personnel 
	And search for Submitted Scholarship Applications
	Update the application to Under Reviewed

################################################
#This is a comment
################################################
#Submit New JPSN Scholarship Application test execution = 1-min
@mytag
Scenario: Submit New JPSN Scholarship Application Hard Coded Data
	Given my login role "JPSNNom1"
	#Given my login role "AutismNom2" 
	#And I select the program "Autism"
	And I select the program "JPSN"
	And I Start a new Scholarship application
	And I Finish a new Scholarship application
	When I Update the Scholarship Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"

#Submit New JPSN Scholarship Application test execution = 1-min
@mytag
Scenario: Submit New JPSN Scholarship Application XML Data
	Given my login role "JPSNNom1"
	#Given my login role "AutismNom2" 
	#And I select the program "Autism"
	And I select the program "JPSN"
	 And I Start a new Scholarship application
	| Filename                   |
	| JPSNScholarshipApplication.xml |
	And I Finish a new Scholarship application
	When I Update the Scholarship Application Status to "Submitted"
	Then The Application Status is displayed as "Submitted"

#Approve New JPSN Scholarship Application test execution = 1-min
@mytag
Scenario: Approve New JPSN Application Hard Coded Data
	#Given my login role "AutismNom2"
	Given I login using ODE Personnel role "ProgramSpecialistJPSN"
	#And I select the program "Autism"
	And I select the program "JPSN"
	And I Search for Scholarship Applications Status "Submitted"
	And I Select Scholarship Record 1
	When I Update the Scholarship Application Status to "Under Review"
	When I Update the Scholarship Application Status to "Review Completed"
	Then The Application Status is displayed as "Eligible"

