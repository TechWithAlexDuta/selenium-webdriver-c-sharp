using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;
using Utils.Common;

namespace TestsDI.Common;

//
// Summary:
//      Config Container to build an Autofac.IContainer from component registrations
public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        // Register the ChromeDriver type as a dependency that implements the IWebDriver interface 
        // and to ensure that only a single instance of ChromeDriver is created and shared across the application.
        builder.RegisterType<ChromeDriver>().As<IWebDriver>().SingleInstance();

        // Register Browser utils class
        builder.RegisterType<Browser>().As<IBrowser>();

        // Register Page Object classes
        // Autofac will recognize constructor parameters and resolve them if they are registered types (e.g. WebDriver).        
        builder.RegisterType<WebFormPage>();        

        return builder.Build();
    }
}