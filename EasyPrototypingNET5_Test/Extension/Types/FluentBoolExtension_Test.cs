//-----------------------------------------------------------------------
// <copyright file="FluentColorExtension_Test.cs" company="PTA GmbH">
//     Class: FluentColorExtension_Test
//     Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>12.05.2021</date>
//
// <summary>
// UnitTest for
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototypingTest
{
    using System;
    using System.Globalization;

    using EasyPrototyping.FluentAPI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FluentBoolExtension_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public FluentBoolExtension_Test()
        {
        }

        [TestMethod]
        public void Bool_ToYesNoStringDE()
        {
            bool input = true;
            string resut = input.This().ToYesNoString();
            Assert.IsTrue(resut == "Ja");
        }

        [TestMethod]
        public void Bool_ToYesNoStringUS()
        {
            bool input = true;
            string resut = input.This().ToYesNoString(new CultureInfo("en-US"));
            Assert.IsTrue(resut == "Yes");
        }

        [TestMethod]
        public void Bool_ToNull()
        {
            bool? input = null;
            string resut = input.This().ToYesNoString();
            Assert.IsTrue(resut == "Nein");
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
