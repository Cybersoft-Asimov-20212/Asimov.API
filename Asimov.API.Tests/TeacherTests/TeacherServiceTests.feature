Feature: TeacherServiceTests
	As a Developer
	I want to register a new Teacher through API
	So that It can be available for applications.
	
	Background: 
		Given the Endpoint https://localhost:5001/auth/sign-up/teacher is available
		And A Director is already stored
		| Id | FirstName | LastName   | Age | Email                  | Password    | Phone     |
		| 1  | Ricardo   | De la Cruz | 42  | ric.cruz1212@gmail.com | Ss924@d#p_s | 918274009 |

@teacher-register
Scenario: Register Teacher
	When A Post Request is sent to Teacher
	 | Point | FirstName | LastName | Age | Email            | Password | Phone     | DirectorId |
	 | 100   | Alexandra | Ortega   | 32  | ale.12@gmail.com | pl012KsQ | 911029382 | 2          |
  	Then A Response with Status 200 is received in Teacher
  	And A Message of "Registration successful." is included in Response Body of Teacher

Scenario: Register Teacher with existing Email
	Given A Teacher is already stored
	  | Point | FirstName | LastName | Age | Email            | Password | Phone     | DirectorId |
	  | 100   | Alexandra | Ortega   | 32  | ale.12@gmail.com | pl012KsQ | 911029382 | 2          |
	When A Post Request is sent to Teacher
	  | Point | FirstName | LastName | Age | Email            | Password | Phone     | DirectorId |
	  | 120   | Carlos    | Ortega   | 40  | ale.12@gmail.com | 99llsdP2 | 911029332 | 1          |
	Then A Response with Status 400 is received
	And A Message of "Email {email request} is already taken." is included in Response Body