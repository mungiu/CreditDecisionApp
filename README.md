# CreditDecisionApp quick description
 This application is part of an interview test.
 The API receives a "GET" request on: localhost:5000/api/decision
 For a quick manual test, launch the application from "..\CreditDecisionAPI\bin\Debug\netcoreapp3.1\publish\CreditDecisionAPI.exe"
 The request body should look the following way (note the types):
```
{
  "appliedAmount": "0,1",
  "monthsRepaymentTerm": 1,
  "totalCurrentDebt": "0,0000001"
}
```
 The respons body will look the following way:
 ```
{
    "TheDecision": "No",
    "InterestRatePercentage": "3"
}
 ```

# Documentation
 Check the "Documentation" folder to find:
 * PowerPoint presentation of important API decisions and the reasoning behind them.
 * Postman test results
 * Postman exported tests

# Task progress
 Check the "Projects" tab to find out how the developer spread the existing work into tasks.
 Or click the link: https://github.com/mungiu/CreditDecisionApp/projects
