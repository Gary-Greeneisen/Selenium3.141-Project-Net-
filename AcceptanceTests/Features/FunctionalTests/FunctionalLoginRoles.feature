Feature: FunctionalLoginRoles
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
	Given my login role "AutismNom1"
	And I select the program "Autism"
	And I Logout

####################################################
#This login format uses only a role
#Use this login format for script debugging
#1. login with role
#2. If(Change Password is displayed) then change the password
#3. Click on a user define product link
#4. Wait and Verify Product Home PAGE
#5. Explicitily logout
####################################################
@MyNameLogin2
Scenario: My Name Login2
	#Use this login to only login to Safe
	Given I login as role "MyName"
	When I Click on link "FSL"
	Then the home page is displayed "Forms and Surveys List"
	And I Logout

####################################################
# Cucumber Table Example
####################################################
@TableDrivenLogin
Scenario Outline: TableDrivenLogin
	Given I login as role "<Role>"
	When I Click on link "<Link>"
	Then the home page is displayed "<HomePageText>"
	And I Logout

Examples: 
| Role							    | Link			     | HomePageText                          |
| AutismNom1                        | Scholarship        | PROGRAM AND ORGANIZATION SELECTION    |
| AutismNom2                        | Scholarship        | PROGRAM SELECTION					 |
| ProgramAdmin                      | Scholarship        | PROGRAM SELECTION				  	 |
| ProgramSpecialistEdChoice         | Scholarship        | PROGRAM SELECTION                     |
| ProgramSpecialistAutism           | Scholarship        | PROGRAM SELECTION                     |


