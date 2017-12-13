using Conversii;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApplicationTests
{
    
    
    /// <summary>
    ///This is a test class for ArithmeticTest and is intended
    ///to contain all ArithmeticTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ArithmeticTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        /// <summary>
        ///A test for computeAddition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void computeAdditionTest()
        {
            Arithmetic_Accessor target = new Arithmetic_Accessor(); // TODO: Initialize to an appropriate value
            string x = "5525"; // TODO: Initialize to an appropriate value
            string digit = "5"; // TODO: Initialize to an appropriate value
            int bNum = 6; // TODO: Initialize to an appropriate value
            string expected = "5534"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.computeAddition(x, digit, bNum);
            Assert.AreEqual(expected, actual);

            x = "1011"; // TODO: Initialize to an appropriate value
            digit = "1"; // TODO: Initialize to an appropriate value
            bNum = 2; // TODO: Initialize to an appropriate value
            expected = "1100"; // TODO: Initialize to an appropriate value
            actual = target.computeAddition(x, digit, bNum);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for computeDivision
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void computeDivisionTest()
        {
            Arithmetic_Accessor target = new Arithmetic_Accessor(); // TODO: Initialize to an appropriate value
            string x = "4523"; // TODO: Initialize to an appropriate value
            string digit = "8"; // TODO: Initialize to an appropriate value
            int bNum = 10; // TODO: Initialize to an appropriate value
            string expected = "565"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.computeDivision(x, digit, bNum);
            Assert.AreEqual(expected, actual);

            x = "777"; // TODO: Initialize to an appropriate value
            digit = "4"; // TODO: Initialize to an appropriate value
            bNum = 8; // TODO: Initialize to an appropriate value
            expected = "177"; // TODO: Initialize to an appropriate value
            actual = target.computeDivision(x, digit, bNum);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for computeMultiplication
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void computeMultiplicationTest()
        {
            Arithmetic_Accessor target = new Arithmetic_Accessor(); // TODO: Initialize to an appropriate value
            string x = "888"; // TODO: Initialize to an appropriate value
            string digit = "9"; // TODO: Initialize to an appropriate value
            int bNum = 10; // TODO: Initialize to an appropriate value
            string expected = "7992"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.computeMultiplication(x, digit, bNum);
            Assert.AreEqual(expected, actual);

            x = "ABCDEF"; // TODO: Initialize to an appropriate value
            digit = "A"; // TODO: Initialize to an appropriate value
            bNum = 16; // TODO: Initialize to an appropriate value
            expected = "6B60B56"; // TODO: Initialize to an appropriate value
            actual = target.computeMultiplication(x, digit, bNum);
            Assert.AreEqual(expected, actual);
           
        }


        /// <summary>
        ///A test for computeSubtraction
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void computeSubtractionTest()
        {
            Arithmetic_Accessor target = new Arithmetic_Accessor(); // TODO: Initialize to an appropriate value
            string x = "10000"; // TODO: Initialize to an appropriate value
            string digit = "2"; // TODO: Initialize to an appropriate value
            int bNum = 16; // TODO: Initialize to an appropriate value
            string expected = "FFFE"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.computeSubtraction(x, digit, bNum);
            Assert.AreEqual(expected, actual);

            x = "1000"; // TODO: Initialize to an appropriate value
            digit = "1"; // TODO: Initialize to an appropriate value
            bNum = 2; // TODO: Initialize to an appropriate value
            expected = "111"; // TODO: Initialize to an appropriate value
            actual = target.computeSubtraction(x, digit, bNum);
            Assert.AreEqual(expected, actual);
           
        }


        /// <summary>
        ///A test for reversedString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void reversedStringTest()
        {
            Arithmetic_Accessor target = new Arithmetic_Accessor(); // TODO: Initialize to an appropriate value
            string s = "1234"; // TODO: Initialize to an appropriate value
            string expected = "4321"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.reversedString(s);
            Assert.AreEqual(expected, actual);

            s = "56"; // TODO: Initialize to an appropriate value
            expected = "65"; // TODO: Initialize to an appropriate value
            actual = target.reversedString(s);
            Assert.AreEqual(expected, actual);
        }
    
    }
}
