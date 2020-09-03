using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTenants_New
{
    [TestClass]
    class CreateTenants
    {
        IWebDriver driver = new ChromeDriver(@"C:\\Users\\Anneline\\source\\repos\\");
        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://cams.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //*************Old Code****************************************************
            //Take this code out when Login Page is correct
            //IWebElement LogInButton = driver.FindElement(By.CssSelector("body > div.lp-content.h-100 > div.card > div.card-body > form > input.btn.btn-primary"));
            //LogInButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine(driver.Title);
        }
        [TestCase]
        public void Login()
        {
            //Enter the Login details
            IWebElement UserName = driver.FindElement(By.Id("LoginInput_UserNameOrEmailAddress"));
            UserName.SendKeys("admin");
            IWebElement PassWord = driver.FindElement(By.Id("LoginInput_Password"));
            PassWord.SendKeys("1q2w3E*");
            IWebElement LoginButton2 = driver.FindElement(By.CssSelector("body > div.d-flex.align-items-center > div > div > div > div.card > div.card-body > div > form > button"));
            LoginButton2.Click();
            //Click on Administration
            IWebElement AdminiStration = driver.FindElement(By.XPath("//*[@id='mCSB_1_container']/nav/ul/li[3]/a/span[2]"));
            AdminiStration.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Click on SaaS
            IWebElement SaAs = driver.FindElement(By.XPath("//*[@id='MenuItem_Abp.Application.Main.Administration']/li[1]/a/span[2]"));
            SaAs.Click();
            //Click on Tenants
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement TeNant = driver.FindElement(By.XPath("//*[@id='MenuItem_SaasHost']/li[1]/a/span[2]"));
            TeNant.Click();

            //Click on the Create button
            IWebElement CreateButton = driver.FindElement(By.Id("NewReferenceDataTypesButton"));
            CreateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Enter Tenant's details
            IWebElement TenantName = driver.FindElement(By.Id("Tenant_Name"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            TenantName.SendKeys("Tester013");
            SelectElement TenantEdition = new SelectElement(driver.FindElement(By.Id("Tenant_EditionId")));
            TenantEdition.SelectByText("Standard");
            IWebElement TenantAdminEmail = driver.FindElement(By.Id("Tenant_AdminEmailAddress"));
            TenantAdminEmail.SendKeys("admin@abp.io");
            IWebElement TenantAdminPwd = driver.FindElement(By.Id("Tenant_AdminPassword"));
            TenantAdminPwd.SendKeys("1q2w3E*");

            //Click on the Save button
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("/html/body/div[4]/form/div/div/div/div[3]/button[2]/span"))).Build().Perform();
            IWebElement SaveButton = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div/div/div[3]/button[2]/span"));
            SaveButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [TearDown]
        public void Logout()
        { 
            //Logout
            Actions action1 = new Actions(driver);
            action1.MoveToElement(driver.FindElement(By.Id("dropdownMenuUser"))).Build().Perform();
            IWebElement manageProfile = driver.FindElement(By.Id("MenuItem_Account.Logout"));
            manageProfile.Click();
            driver.Quit();
        }
    }
}
