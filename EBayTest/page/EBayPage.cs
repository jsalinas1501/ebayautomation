using EBayTest.client;
using EBayTest.properties;
using EBayTest.selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EBayTest.page
{
    class EBayPage
    {
        static List<Product> listproduct = new List<Product>();

        public static void Initialize(string navigator)
        {
            
            if (navigator.Equals("chrome"))
            {
                Properties.driver = new ChromeDriver(Environment.CurrentDirectory);
            } else if(navigator.Equals("edge"))
            {
                Properties.driver = new EdgeDriver(Environment.CurrentDirectory);
            } else if(navigator.Equals("ie"))
            {
                Properties.driver = new InternetExplorerDriver(Environment.CurrentDirectory);
            }
            Properties.driver.Manage().Window.Maximize();
            Properties.driver.Manage().Cookies.DeleteAllCookies();
            Properties.driver.Navigate().GoToUrl("https://www.ebay.com/");
        }

        public static void SearchProduct(string value)
        {
            SeleniumSetMethods.EnterText(Properties.driver, "gh-ac",value,"Id");
            SeleniumSetMethods.Click(Properties.driver, "gh-btn", "Id");
            SeleniumSetMethods.Wait(Properties.driver, "srp-river-results", "Id");
        }

        public static void SelectBrand(string brand)
        {
            ICollection<IWebElement> elements = SeleniumGetMethods.GetElements(Properties.driver, "//div[@id='w3-w12']//span[1]", "xpath");

            foreach (IWebElement element in elements)
            {
                if (element.Text.ToLower().Trim().Equals(brand))
                {
                    element.Click();
                    return;
                }
            }
        }

        public static void SelectSize(string size)
        {
            ICollection<IWebElement> elements = SeleniumGetMethods.GetElements(Properties.driver, "//*[@id=\"w3\"]/li[1]/ul/li[2]/ul/li[1]/ul//span[1]", "xpath");

            foreach (IWebElement element in elements)
            {
                if (element.Text.ToLower().Trim().Equals(size))
                {
                    element.Click();
                    return;
                }
            }

            PrintResults("Number of Results: " + SeleniumGetMethods.GetText(Properties.driver, "srp-controls__count-heading", "Class"));
        }

        public static void OrderByPriceAscendant()
        {
            SeleniumSetMethods.PerformMovement(Properties.driver,SeleniumGetMethods.GetElement(Properties.driver,"w7","Id"));
            SeleniumSetMethods.Click(Properties.driver, "//*[@class='srp-sort__menu']/li[4]", "xpath");

            //printing first 5 results in console
            listproduct=SeleniumGetMethods.GetProductsFromList(Properties.driver, 5);

            foreach (Product element in listproduct)
            {
                PrintResults(element.GetTitle());
                PrintResults(element.GetPrice());
            }
            
        }

        public static void OrderByNameAscendant()
        {
            listproduct.Sort(new Comparer());

            foreach (Product element in listproduct)
            {
                PrintResults(element.GetTitle());
                PrintResults(element.GetPrice());
            }
        }

        public static void OrderByPriceDescendant()
        {
            listproduct.Sort(new DoubleComparer());

            foreach (Product element in listproduct)
            {
                PrintResults(element.GetTitle());
                PrintResults(element.GetPrice());
            }
        }

        public static void PrintResults(string val)
        {
            Console.WriteLine(val);
        }

    }
}
