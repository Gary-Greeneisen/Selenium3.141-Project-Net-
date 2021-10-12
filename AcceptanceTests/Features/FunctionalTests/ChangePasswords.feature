Feature: ChangePasswords
		Change/Update the password for the login Role


@ChangePasswords
Scenario: Change Passwords
	#Given A User Role "DFAdmin"
	Given A User Role "ProgramSpecialistAutism"
	When I change the passsword
	Then I Logout
