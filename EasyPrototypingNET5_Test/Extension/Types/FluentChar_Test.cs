//-----------------------------------------------------------------------
// <copyright file="FluentChar_Test.cs" company="Lifeprojects.de">
//     Class: FluentChar_Test
//     Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>12.05.2021</date>
//
// <summary>
// UnitTest for Fluent Char
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototypingTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using EasyPrototyping.FluentAPI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FluentChar_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public FluentChar_Test()
        {
        }

        [TestMethod]
        public void CharInList()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'z' };
            bool value = 'b'.This().In(chars);

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void CharNotInList()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'z' };
            bool value = 'x'.This().NotIn(chars);

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void ToIEnumerable()
        {
            IEnumerable<char> result = 'a'.This().ToIEnumerable('c');
            int count = result.Count();
            Assert.IsTrue(count == 3);
        }

        [TestMethod]
        public void UnicodeCategory()
        {
            char c1 = 'a';
            Assert.IsTrue(c1.This().GetUnicodeCategory() == System.Globalization.UnicodeCategory.LowercaseLetter);

            char c2 = '.';
            Assert.IsTrue(c2.This().GetUnicodeCategory() == System.Globalization.UnicodeCategory.OtherPunctuation);
        }

        [DataRow("", "")]
        [TestMethod]
        public void DataRowInputTest(string input, string expected)
        {
        }

        [TestMethod]
        public void ExceptionTest()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }
    }
}