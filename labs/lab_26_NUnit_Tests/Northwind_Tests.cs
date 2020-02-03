using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using lab_37_northwind_core;

namespace lab_26_NUnit_Tests
{
    public class Northwind_Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        // tests go here 
        [Test]
        public void NorthwindDummyTest()
        {
            Assert.AreEqual(91, 91);
        }
    }
}
