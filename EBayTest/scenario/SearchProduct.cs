using EBayTest;
using EBayTest.page;
using EBayTest.properties;
using EBayTest.scenario;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Tests
{
    public class SearchProduct : TestBase
    {
        
        static void Main(string[] args)
        {

        }

        [Test]
        public void SearchOn()
        {
            EBayPage.SearchProduct("shoes");
            EBayPage.SelectBrand("puma");
            EBayPage.SelectSize("10");
            EBayPage.OrderByPriceAscendant();
            EBayPage.OrderByNameAscendant();
            EBayPage.OrderByPriceDescendant();
        }

        
    }
}