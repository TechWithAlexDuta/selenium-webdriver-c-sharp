# selenium-webdriver-c-sharp
Tutorials and sample web automation framework using Selenium WebDriver and C#  

## Installation
1. Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) or newer installed on your machine (projects were developed using .NET 8). Check installation
    ```PS
    dotnet --version
    ```
2. Clone this repository to your local machine.
3. Open the solution (`SeleniumWebDriverProject.sln`) in Visual Studio or folder (`selenium-webdriver-c-sharp`) in VS Code or your preferred IDE. 
4. Build solution from IDE or from terminal navigate under solution folder or a project you want to build and run  `dotnet build` (implicit restore).
    ```PS
    dotnet build
    ```

## Usage
1. Make sure you have the appropriate browser installed (`https://www.selenium.dev/documentation/webdriver/browsers/`)
2. Open the solution directory in VS Code or your preferred IDE. 
3. Using terminal navigate to a project (cd command) and run
    ```PS
    dotnet build
    ```
4. Run the tests using your preferred test runner or IDE. From terminal, in your project folder, change "net_version" and "project_name" e.g.
    ```PS
    dotnet test .\bin\Debug\net_version\project_name.dll
    ```
5. Optional: check reports (depending on the project you run, the reports may by integrated with ExtentReports or Allure)

## Tech
- .NET 8   
- C#  
- Selenium WebDriver  
- NUnit  
- .NET.Test.SDK  
- Extent Reports
- Allure
- Autofac

## Design patterns
- Page Object Model
- Singleton (Extent reports)
- Dependency Injection (Autofac)

## Tutorials:
- First Selenium test
- Introduction to browser drivers
- Locators, relative locators
- Find element(s) on the web page
- Web elements interactions
- Wait conditions
- First Selenium framework
- Extent reports
- Allure reports
- Singleton
- Parallel run
- Dependency Injection

## YT channel
Please check my YouTube channel for step by step implementation or detailed tutorials on automation and more: https://www.youtube.com/@TechWithAlexDuta

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.