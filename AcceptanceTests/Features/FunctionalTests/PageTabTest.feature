Feature: PageTab Test
	Test Each Page tabs based on User role and Program Type

@mytag
#Scenario: ProviderSearch
	#Given I login as role "JPSNAdmin"
	#Given I login as role "EdChoiceNom1"
	#And I Click on link "Scholarship"
	#And I select the program "EdChoice"
	#And I Select Provider Search
	#When I Search
	#And I Select Provider Record 1
	#Then I Test All Provider Search Page Tabs

@TableDrivenProviderSearch
Scenario Outline: ProviderSearch
	Given I login as role "<Role>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	And I Select Provider "Search Provider"
	When I Search For Provider
	And I Select Provider Record 1
	Then I Test All Provider Search Page "<Tabs>"

Examples: 
| Role			|  Safe Link  | Program  | Tabs																	 |
| JPSNAdmin		| Scholarship | EdChoice | General,Personnel,Staff,Tuition,Docs,Status/Flags,Comments/History	 |
| JPSNNom1		|Scholarship  | Autism	 | General,Personnel,Services,Staff,Comments/History					 |
| ProgramAdmin  |Scholarship  | Autism	 | General,Personnel,Services,Staff,Docs,Status/Flags,Comments/History	 |


@TableDrivenProviderSearch2
##This scenario does not use the menu selections
##The Provider Page is displayed by default after login
Scenario Outline: ProviderSearch2
	Given I login as role "<Role>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	When I Search For Provider
	And I Select Provider Record 1
	Then I Test All Provider Search Page "<Tabs>"

Examples: 
| Role				|  Safe Link	| Program	| Tabs																					 |
| ProgramAdmin22+	| Adult Learner	| NA		| General,Personnel,ApplicationQuestions,Participating Buildings,Docs,Status/Flags,Comments/History |



@TableDrivenStudentSearch
Scenario Outline: StudentSearch
	Given I login as role "<Role>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	And I Select Student "Search Scholarship Application"
	When I Search For Student
	And I Select Student Record 1
	Then I Test All Student Search Page "<Tabs>"

Examples: 
| Role      | Safe Link		| Program	| Tabs																									|
| JPSNAdmin | Scholarship	| EdChoice	| Student,PARENT/GUARDIAN,INCOME VERIFICATION,Application,Assessment,Docs,Status/Flags,Comments/History	|
| JPSNNom1  | Scholarship	| JPSN		| Student,PARENT/GUARDIAN,Application,IEP,Assessment,Docs,Status/Flags,Comments/History				    |
| JPSNAdmin | Adult Learner |  NA 		| Student,Application,Graduation Requirements,Student Success Plan,Assessment,Docs,Status/Flags,Comments/History	|


@TableDrivenParentStudentSearch1
Scenario Outline: ParentStudentSearch1
	Given I login as role "<Parent>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	And I Select Student "Search Scholarship Application"
	When I Search For Student
	And I Select Student Record 1
	Then I Test All Parent Student Search Page "<Tabs>"

Examples: 
| Parent			 | Safe Link		| Program	| Tabs																									|
| Scholarship.Parent | Scholarship		| Autism	| Student,PARENT/GUARDIAN,Application,IEP,Docs,Status/Flags,Comments/History	|
| Scholarship.Parent | Scholarship		| JPSN		| Student,PARENT/GUARDIAN,Application,IEP,Docs,Status/Flags,Comments/History	|


@TableDrivenParentStudentSearch2
Scenario Outline: ParentStudentSearch2
	Given I login as role "<Parent>"
	And I Click on link "<Safe Link>"
	And I select the parent program "<Program>"
	And I Select Student "Search College Credit Plus Application"
	When I Search For Student
	And I Select Student Record 1
	Then I Test All Parent Student Search Page "<Tabs>"

Examples: 
| Parent		 | Safe Link				| Program		| Tabs																									|
| Parent.CCP	 | College Credit Plus		| Home School	| Student,PARENT/GUARDIAN,Application,Credit Hours,Docs,Status/Flags,Comments/History	|
| Parent.CCP	 | College Credit Plus		| Nonpublic		| Student,PARENT/GUARDIAN,Application,Credit Hours,Docs,Status/Flags,Comments/History	|


@TableDrivenFinanceSearch
Scenario Outline: FinanceSearch
	Given I login as role "<Role>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	And I Select Finance "Finance Search"
	When I Search For Finance Student
	And I Select Finance Record 1
	Then I Test All Student Finance Search Page "<Tabs>"

Examples: 
| Role			|  Safe Link  | Program  | Tabs																								|
| AutismNom1	| Scholarship | Autism   | Allocation Form,Progress Report, Invoice,Account Summary,Payment,Finance Docs,Finance Comments	|


@TableDrivenAdminSearch
Scenario Outline: AdminSearch
	Given I login as role "<Role>"
	And I Click on link "<Safe Link>"
	And I select the program "<Program>"
	And I Select Menu "Admin Programs"
	And I Select Admin Record 1
	Then I Test All Admin Pages "<Tabs>"

Examples: 
| Role						|  Safe Link	| Program	| Tabs																				|														
| JPSNAdmin					| Adult Learner |  NA 		| Program Management,Funding Category Setup,Billing Schedule						|
| JPSNAdmin					| Scholarship   | JPSN 		| Program Management,Funding Category Setup,Billing Schedule,Addin/Deduct Schedule	|
| ProgramSpecialistAutism	| Scholarship   | Autism 	| Program Management,Funding Category Setup,Billing Schedule,Addin/Deduct Schedule	|
| ProgramSpecialistEdChoice	| Scholarship   | EdChoice 	| Program Management,Funding Category Setup,Billing Schedule,Addin/Deduct Schedule	|













