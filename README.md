# AutomationFrameworkRepo_v01

## Overview  
This repository demonstrates a basic test automation framework in C# using:  
- **RestSharp** for API testing  
- **Selenium WebDriver** for UI automation  
- **Extent Reports** for generating HTML reports  

The framework is designed to show test case structure, execution, and reporting.
There are 3-test cases, two API and one UI. One of the API is set to fail intentionally.

## Installation 
Clone this repository 
```bash
git clone https://github.com/tdonaldson231/AutomationFrameworkRepo_v01.git
```
Navigate to the project directory
```bash
cd AutomationFrameworkRepo_v01
```
## Execution 
### Visual Studio 2022
- Open the solution: `AutomationFramework.sln`
- Go to `Build > Build Solution`
- Then go to `Tests > Run All Tests`
 
### Command Line (dotnet)
From the home directory, execute the following to run all tests
```bash
dotnet test AutomationFramework/bin/Debug/AutomationFramework.dll
```
Results
```bash
VSTest version 17.12.0 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
  Failed WebSiteAPIPostDataBackendService [408 ms]
  Error Message:
     Expected string length 2 but was 7. Strings differ at index 0.
  Expected: "OK", ignoring case
  But was:  "Created"
  -----------^

  Stack Trace:
     at AutomationFramework.WebSiteAPI.WebSiteAPIPostDataBackendService() in ~\AutomationFrameworkRepo_v01\AutomationFramework\WebSiteAPI.cs:line 92


Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3, Duration: 7s
```

## Results 
Extent Html Reports are generated with date/timestamps in the `Reports` directory
