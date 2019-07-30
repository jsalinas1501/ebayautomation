using EBayTest.client;
using EBayTest.properties;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBayTest.selenium
{
    class SeleniumGetMethods
    {
        public static string GetText(IWebDriver driver, string element, string elementType)
        {
            if (elementType.Equals("Id"))
                return driver.FindElement(By.Id(element)).Text;
            else if (elementType.Equals("Name"))
                return driver.FindElement(By.Name(element)).Text;
            else if (elementType.Equals("Class"))
                return driver.FindElement(By.ClassName(element)).Text;
            else if (elementType.Equals("xpath"))
                return driver.FindElement(By.XPath(element)).Text;
            else return String.Empty;
        }

        public static IWebElement GetElement(IWebDriver driver, string element, string elementType)
        {
            if (elementType.Equals("Id"))
                return driver.FindElement(By.Id(element));
            else if (elementType.Equals("Name"))
                return driver.FindElement(By.Name(element));
            else return null;
        }

        public static ICollection<IWebElement> GetElements(IWebDriver driver, string element, string elementType)
        {
            if (elementType.Equals("Class"))
                return driver.FindElements(By.ClassName(element));
            else if (elementType.Equals("xpath"))
                return driver.FindElements(By.XPath(element));
            else return null;
        }

        public static List<Product> GetProductsFromList(IWebDriver driver, int units)
        {
            string itemcontainer = "";
            List<Product> listproduct = new List<Product>();
            Product product = new Product();

            for (int i = 0; i < units; i++)
            {
                product = new Product();
                itemcontainer = "//*[@id=\"srp-river-results-listing" + (i + 1) + "\"]";
                product.SetTitle(GetText(Properties.driver, itemcontainer + "//*[@class='s-item__title']", "xpath"));
                product.SetPrice(GetText(Properties.driver, itemcontainer + "//*[@class='s-item__price']", "xpath"));
                listproduct.Add(product);
            }

            return listproduct;
        }
    }
}
