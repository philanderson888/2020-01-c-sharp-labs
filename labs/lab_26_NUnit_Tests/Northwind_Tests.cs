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

 


        [TestCase("Berlin",10)]
        public void Number_Of_Northwind_Customers_Test(string city, int expected)
        {
            var instance = new Northwind_Code();
            var actual = instance.NumberOfNorthwindCustomers(city);
            Assert.AreEqual(expected, actual);
        }


        #region TestNumberOfNorthwindCustomers
        /* Create a class to read in Northwind customers and return the total
         * Then repeat for just London customers
         * */
        [TestCase(null, 91)]    // how many customers total?
        [TestCase("London", 6)] // how many customers in London?
        [TestCase("Berlin", 1)]  // how many in berlin
        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
            // arrange
            var instance = new Northwind_Code();
            // act
            var actual = instance.NumberOfNorthwindCustomers(city);
            // assert
            Assert.AreEqual(expected, actual);
        }
        #endregion





        #region TestNumberOfProductsStartingWithAndContainingAParticularLetter
        [TestCase(3)]
        public void TestNumberOfProductsStartingWithP(int expected)
        {
            // arrange (instance)
            var instance = new Northwind_Code();
            // act (method)
            var actual = instance.TestNumberOfProductsStartingWithP();
            // assert 
            Assert.AreEqual(expected, actual);
        }
        [TestCase("p", 3)]
        public void TestNumberOfProductsStartingWithALetter(string letter, int expected)
        {
            // arrange (instance)
            var instance = new Northwind_Code();
            // act (method)
            var actual = instance.TestNumberOfProductsStartingWithALetter(letter);
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase("p", 17)]
        [TestCase("a", 58)]
        [TestCase("d", 30)]
        public void TestNumberOfProductsContainingALetter(string letter, int expected)
        {
            // arrange (instance)
            var instance = new Northwind_Code();
            // act (method)
            var actual = instance.TestNumberOfProductsContainingALetter(letter);
            // assert 
            Assert.AreEqual(expected, actual);
        }
        #endregion



    }
}
