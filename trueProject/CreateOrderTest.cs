using automationTrueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace trueProject
{
    [TestClass]
    public class CreateOrderTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }


        [TestMethod]
        public void UserCanCreateOrder()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("standard_user")
                .WithPassword("secret_sauce")
                .Login();

            InventoryPage.OrderProductBy("Price (low to high)")
                .AddItemToCart("Sauce Labs Backpack")
                .AddItemToCart("Sauce Labs Fleece Jacket")
                .GoToShoopingCart();

            CartPage.Initialize()
                .VerifyItemPrice("Sauce Labs Backpack", "29.99")
                .VerifyItemPrice("Sauce Labs Fleece Jacket", "49.99")
                .Checkout();

            CheckOutStepOnePage.CheckoutAs("Purple")
                .WithLastName("Automation")
                .WithCodeZip("12345")
                .Continue();

            CheckOutStepTwoPage.VerifyTotal("79.98")
                .WithTax("6.40")
                .withTotalAndTaxes("86.38")
                .Finish();

            Assert.IsTrue(CheckoutCompletePage.IsOrderCompleted("THANK YOU FOR YOUR ORDER"), "Order was not completed");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
