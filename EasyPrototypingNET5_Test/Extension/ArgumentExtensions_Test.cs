using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyPrototypingTest
{
    [TestClass]
    public class ArgumentExtensions_Test
    {
        [TestMethod]
        public void IsArgumentNull()
        {
            try
            {
                this.TestOfNull(string.Empty);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentNullForObject()
        {
            try
            {
                List<string> liste = null;
                this.TestOfNull(liste);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentNullForObjectWithDefault()
        {
            try
            {
                List<string> liste = null;
                this.TestOfNullWithDefault(liste);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentEmptyOrNull()
        {
            try
            {
                this.TestOfEmptyOrNull(string.Empty);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }

        [TestMethod]
        public void IsArgumentEmptyOrNullWithDefault()
        {
            try
            {
                string result = this.TestOfEmptyOrNullWithDefault(string.Empty);
                Assert.IsTrue(result == "Gerhard");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }

        [TestMethod]
        public void IsArgumentEnum()
        {
            try
            {
                this.TestOfEnum(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void IsArgumentEnumDefaultEnum()
        {
            try
            {
                Test result = (Test)this.TestOfEnumWithDefaultEnum();
                Assert.IsTrue(result == Test.Nix);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void IsArgumentNullWithDefaultString()
        {
            try
            {
                string result = this.TestOfNullWithDefaultString(null);
                Assert.IsTrue(result == "Gerhard");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentNullWithDefaultDateTime19000101()
        {
            try
            {
                DateTime result = this.TestOfNullWithDefaultDateTime1900(null);
                Assert.IsTrue(result == new DateTime(1900, 1, 1));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentNullWithDefaultDateTime()
        {
            try
            {
                DateTime? result = this.TestOfNullWithDefaultDateTime(null);
                Assert.IsTrue(result == new DateTime(2020, 09, 20));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void IsArgumentOutOfRange()
        {
            try
            {
                int size = 0;
                size = size.IsArgumentOutOfRange("Size", size == 0);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

        private void TestOfEmptyOrNull(string value)
        {
            value.IsArgumentEmptyOrNull(nameof(value));
        }

        private string TestOfEmptyOrNullWithDefault(string value)
        {
            return value.IsArgumentEmptyOrNull(nameof(value),"Gerhard");
        }

        private void TestOfNull(string value)
        {
            value.IsArgumentNull(nameof(value));
        }

        private void TestOfNull(List<string> value)
        {
            List<string> result = value.IsArgumentNull(nameof(value));
        }

        private void TestOfNullWithDefault(List<string> value)
        {
            List<string> result = value.IsArgumentNull(nameof(value), new List<string>() { "Gerhard" });
        }

        private string TestOfNullWithDefaultString(string value)
        {
            return value.IsArgumentNull(nameof(value),"Gerhard");
        }

        private DateTime TestOfNullWithDefaultDateTime1900(DateTime? value)
        {
            return value.IsArgumentNull("Value");
        }

        private DateTime? TestOfNullWithDefaultDateTime(DateTime? value)
        {
            DateTime? toDay = new DateTime(2020, 09, 20);
            return value.IsArgumentNull("Value", toDay);
        }

        private void TestOfEnum(Nullable<Test> value)
        {
            value.IsArgumentInEnum(nameof(value));
        }

        private Test TestOfEnumWithDefaultEnum(Nullable<Test> value = null)
        {
            Nullable<Test> e = Test.Nix;
            Test result = (Test)value.IsArgumentInEnum(nameof(value), e);
            return result;
        }
    }

    internal enum Test
    {
        None = 0,
        Alles = 1,
        Nix = 2
    }
}