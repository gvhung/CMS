using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;
namespace UtilityTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void SendEmailSuccess()
        {
            EmailUtilty.SendEmail("williams14u@gmail.com", "mkbondada@gmail.com", "Test","Hi", false);

        }

    }
}
