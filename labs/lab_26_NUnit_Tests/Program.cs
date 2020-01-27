using System;
using NUnit;
using NUnit.Framework;
using lab_27_test_addition;
using lab_28_code_to_pass_tests;

namespace lab_26_NUnit_Tests
{

    class NUnit_Tests
    {
        // CREATE UNIFORM TESTING ENVIRONMENT - PERHAPS LOAD STARTUP INFO FROM DATABASE
        [SetUp]
        public void Setup()
        {

        }


        [TestCase(1,2,3)]
        [TestCase(3,6,9)]
        [TestCase(5,7,12)]
        [TestCase(2,2,4)]
        [TestCase(1000,2000,3000)]
        public void TestAdditionDemo(int a, int b, int expected)
        {
            // Arrange - set up test ready to run.  
            //         - create instances of test classes
            var instance = new Addition();

            // Act - run code to get 'actual' value
            var actual = instance.AddTwoNumbers(a, b);

            // Assert - assert.AreEqual(actual,expected);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2,2,2)]
        [TestCase(3,3,9)]

        public void Sum2DArrayTest(int numrows, int numcolumns, int expected)
        {
            // arrange

            // act

            // assert
        }

        [TestCase(3,3,3,27)]
        [TestCase(4,4,4,96)]
        public void Sum3DCubeTest(int x,int y, int z, int expected)
        {
            // arrange
            var instance = new Basic_Tests();
            // act
            var actual = instance.Test_120_Sum_3D_Cube(x,y,z);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, 3, 27)]
        [TestCase(4, 4, 4, 96)]
        public void Sum3DCubeTest2(int x, int y, int z, int expected)
        {
            // arrange
            var instance = new Basic_Tests();
            // act
            var actual = instance.Test_120_Sum_3D_Cube_With_ForEach(x, y, z);
            // assert
            Assert.AreEqual(expected, actual);
        }

        


    }


}
