Feature: Login HR Sale

This is Demo Playwright.
Using: POM, Dependency Injection, ConfigReader(ASP.NET Core)

@TC001 @LoginSuccess
Scenario: Verify User Login HRSale successfully
	Given Navigate to 'HRSale'

	# Login with Super Admin account
	When Input with following Username and Password
	| fields   | value       |
	| Username | Super Admin |
	| Password | Super Admin |
	Then Verify User login successfully with message 'Logged In Successfully.'
	Then Click Logout button

	# Login with Employee account
	When Input with following Username and Password
	| fields   | value    |
	| Username | Employee |
	| Password | Employee |
	Then Verify User login successfully with message 'Logged In Successfully.'
	Then Click Logout button

	# Login with Client account
	When Input with following Username and Password
	| fields   | value  |
	| Username | Client |
	| Password | Client |
	Then Verify User login successfully with message 'Logged In Successfully.'
	Then Click Logout button


@TC002 @LoginUnSuccessful
Scenario: Verify User Login HRSale unsuccessfully when missing informations
	Given Navigate to 'HRSale'

	# Login without Username
	When Input with following Username and Password
	| fields   | value       |
	| Username |             |
	| Password | Super Admin |
	Then Verify User login unsuccessfully with message 'The username field is required.'

	# Login without Password
	Given Navigate to 'HRSale'
	When Input with following Username and Password
	| fields   | value       |
	| Username | Super Admin |
	| Password |             |
	Then Verify User login unsuccessfullyd with message 'The password field is required.'