Feature: LoginRoles
		Login as an Various Roles
		And display the Application Home Page

################################################
#This is a comment
################################################


################################################
# There is no multi-line/block cucumber comments
################################################

####################################################
#This login format uses a role and constant pre-defined product link, based on product name
#Use this login format to do the following:
#1. login with role
#2. If(Change Password is displayed) then change the password
#3. Click on a constant pre-defined product link
#4. Wait and Verify Product Home PAGE
#5. There is no Logout. The logout is the last part of the scenario
####################################################
@Login1
Scenario: Login1
	#Use this login to login to Safe and display the product home page
	Given my login role "AutismNom2"
	And I select the program "Autism"
	And I Logout

@TableDrivenProgram
Scenario Outline: TableDrivenProgram
	Given my login role "<Role>"
	And I select the program "<Program>"
	And I Logout

Examples: 
| Role       | Program		|
| AutismNom2 | Autism		|   
| AutismNom2 | Cleveland	| 
| AutismNom2 | EdChoice		| 
| AutismNom2 | EdChoice-Exp	| 
| AutismNom2 | JPSN			|      


@MyNameLogin2
Scenario: MyName Login2
#Use this login to only login to Safe
	Given I login as role "MyName"
	When I wait for the SAFE home page
	And I Click on link "FSL"
	Then the home page is displayed "Forms and Surveys List"
	And I Logout

@InValidLogin
Scenario: Display Login Error Msg
	Given I login as invalid role "xyz"
	Then the login error is displayed "The user name or password provided is incorrect."

@ScholarshipLoginProvider1
Scenario: Scholarship Login Autism Nominator
	Given I login as role "AutismNom1"
	When I wait for the SAFE home page
	And I Click on link "Scholarship"
	Then the home page is displayed "PROGRAM AND ORGANIZATION SELECTION"
	And I Logout


