Feature: Demo API Service

This is a demo of simple API testing using the endpoint https://reqres.in/api with RestSharp. 
You can extend it at anytime when needed.

@TC003 @APITesting @DemoAPI
Scenario: Verify Get Method
	When Send 'Get'
	Then Verify Status code is '200'



@TC004 @APITesting @DemoAPI
Scenario: Verify Post Method
	When Send 'Post'
	Then Verify Status code is '201'
