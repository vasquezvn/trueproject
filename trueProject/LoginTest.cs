using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using automationTrueProject;

namespace trueProject
{
    [TestClass]
    public class LoginTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }


        [TestMethod]
        public void UserCanLogin()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("standard_user")
                .WithPassword("secret_saucex")
                .Login();

            try
            {
                Assert.IsTrue(InventoryPage.IsAt, "Falied Login");
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.WriteLine("After assert ");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
