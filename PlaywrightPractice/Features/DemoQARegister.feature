Feature: DemoQARegister

This page is used for automation testing of DemoQA.com.
Using: POM, Dependency Injection, ConfigReader(ASP.NET Core)

@TC005
Scenario: Verify Register User in DemoQA Page
	Given Navigate to 'DemoQA' 
	When Input the following field for register user
	| fields    | value               |
	| FirstName | TienTD              |
	| LastName  | TienTD              |
	| Email     | TienTD Email        |
	| Mobile    | TienTD Phone Number |
	When Click Submit button
	Then Verify 'Thanks for submitting the form' message is displayed
