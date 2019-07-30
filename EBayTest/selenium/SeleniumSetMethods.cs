using EBayTest.client;
using EBayTest.properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBayTest
{
    class SeleniumSetMethods
    {
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType.Equals("Id"))
                driver.FindElement(By.Id(element)).SendKeys(value);
            else if (elementType.Equals("Name"))
                driver.FindElement(By.Name(element)).SendKeys(value);
        }

        public static void Click(IWebDriver driver, string element, string elementType)
        {
            if (elementType.Equals("Id"))
                driver.FindElement(By.Id(element)).Click();
            else if (elementType.Equals("Name"))
                driver.FindElement(By.Name(element)).Click();
            else if (elementType.Equals("Class"))
                driver.FindElement(By.ClassName(element)).Click();
            else if (elementType.Equals("xpath"))
                driver.FindElement(By.XPath(element)).Click();

        }

        public static void Wait(IWebDriver driver, string element, String elementType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            if(elementType.Equals("Id"))
                wait.Until(ExpectedConditions.ElementExists(By.Id(element)));
            else if(elementType.Equals("Name"))
                wait.Until(ExpectedConditions.ElementExists(By.Name(element)));
            else if (elementType.Equals("Class"))
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(element)));
        }

        public static void PerformMovement(IWebDriver driver, IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }

        
    }
}
