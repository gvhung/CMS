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
            string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>Plese Click below link for Activation<br/><br/> Thanks and Regards<br/>CRM Admin";
            EmailUtilty.SendEmail("williams14u@gmail.com", "mkbondada@gmail.com", "Welcom to CRM Bug Tracker", Msg , true);

        }

    }
}
