using Conversii;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApplicationTests
{
    
    
    /// <summary>
    ///This is a test class for ConversionsTest and is intended
    ///to contain all ConversionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConversionsTest
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
        ///A test for fromBaseToBase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void fromBaseToBaseTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            int from = 10; // TODO: Initialize to an appropriate value
            int to = 2; // TODO: Initialize to an appropriate value
            string x = "3"; // TODO: Initialize to an appropriate value
            string expected = "11"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.fromBaseToBase(from, to, x);
            Assert.AreEqual(expected, actual);


            from = 5; // TODO: Initialize to an appropriate value
            to = 6; // TODO: Initialize to an appropriate value
            x = "3"; // TODO: Initialize to an appropriate value
            expected = "3"; // TODO: Initialize to an appropriate value
            actual = target.fromBaseToBase(from, to, x);
            Assert.AreEqual(expected, actual);
        }

        

        /// <summary>
        ///A test for getChar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void getCharTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            int s = 11; // TODO: Initialize to an appropriate value
            char expected = 'B'; // TODO: Initialize to an appropriate value
            char actual;
            actual = target.getChar(s);
            Assert.AreEqual(expected, actual);

            s = 4; // TODO: Initialize to an appropriate value
            expected = '4'; // TODO: Initialize to an appropriate value
            actual = target.getChar(s);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for getInt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void getIntTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            char s = '5'; // TODO: Initialize to an appropriate value
            int expected = 5; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.getInt(s);
            Assert.AreEqual(expected, actual);

            s = 'B'; // TODO: Initialize to an appropriate value
            expected = 11; // TODO: Initialize to an appropriate value
            actual = target.getInt(s);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for rapidConversion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void rapidConversionTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            int from = 16; // TODO: Initialize to an appropriate value
            int to = 2; // TODO: Initialize to an appropriate value
            string x = "CDF"; // TODO: Initialize to an appropriate value
            string expected = "1100 1101 1111 "; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.rapidConversion(from, to, x);
            Assert.AreEqual(expected, actual);

            from = 2; // TODO: Initialize to an appropriate value
            to = 16; // TODO: Initialize to an appropriate value
            x = "10101011000"; // TODO: Initialize to an appropriate value
            expected = "558"; // TODO: Initialize to an appropriate value
            actual = target.rapidConversion(from, to, x);
            Assert.AreEqual(expected, actual);
        }

        
        /// <summary>
        ///A test for substitutionMethod
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void substitutionMethodTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            int from = 10; // TODO: Initialize to an appropriate value
            int to = 16; // TODO: Initialize to an appropriate value
            string x = "5896"; // TODO: Initialize to an appropriate value
            string expected = "1708"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.substitutionMethod(from, to, x);
            Assert.AreEqual(expected, actual);

            from = 2; // TODO: Initialize to an appropriate value
            to = 16; // TODO: Initialize to an appropriate value
            x = "1010101"; // TODO: Initialize to an appropriate value
            expected = "55"; // TODO: Initialize to an appropriate value
            actual = target.substitutionMethod(from, to, x);
        }


        /// <summary>
        ///A test for substitutionMethod
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Conversii.exe")]
        public void successveDivisionsTest()
        {
            Conversions_Accessor target = new Conversions_Accessor(); // TODO: Initialize to an appropriate value
            int from = 10; // TODO: Initialize to an appropriate value
            int to = 16; // TODO: Initialize to an appropriate value
            string x = "5896"; // TODO: Initialize to an appropriate value
            string expected = "1708"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.successveDivisions(from, to, x);
            Assert.AreEqual(expected, actual);

            from = 2; // TODO: Initialize to an appropriate value
            to = 16; // TODO: Initialize to an appropriate value
            x = "1010101"; // TODO: Initialize to an appropriate value
            expected = "55"; // TODO: Initialize to an appropriate value
            actual = target.successveDivisions(from, to, x);
        }

        
    }
}
