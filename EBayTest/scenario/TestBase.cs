using EBayTest.page;
using EBayTest.properties;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBayTest.scenario
{
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            EBayPage.Initialize("chrome");
        }

        [TearDown]
        public void Teardown()
        {
            Properties.driver.Close();
        }
    }
}
