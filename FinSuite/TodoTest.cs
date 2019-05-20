using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace FinSuite
{
    [TestClass]
    public class TodoTest
    {
        [TestMethod]
        public void AddandEditTodo()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://todomvc.com/";
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().i(TimeSpan.FromSeconds(10));
            driver.FindElement(By.XPath("//div[@id='tabsContent']/paper-tab[3]/div[.='Labs']")).Click();
            driver.FindElement(By.XPath("//li/a[@data-source='http://angular.io']")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']")).SendKeys("Todo1");
            driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']")).SendKeys(Keys.Tab);

            Thread.Sleep(3000);
            Actions actions = new Actions(driver);
            IWebElement elementLocator = driver.FindElement(By.XPath("/html/body/todo-app/section/section/ul/li/div/label"));
            actions.DoubleClick(elementLocator).Perform();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@class='edit']")).SendKeys("Updated");
            driver.FindElement(By.XPath("//input[@class='edit']")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();

        }




    }
}
