using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace automationTrueProject
{
    public class CheckOutStepTwoPageCommand
    {
        private string subtotal;
        private string tax;
        private string total;

        public CheckOutStepTwoPageCommand(string subtotal)
        {
            this.subtotal = subtotal;
        }

        public CheckOutStepTwoPageCommand WithTax(string tax)
        {
            this.tax = tax;

            return this;
        }

        public CheckOutStepTwoPageCommand withTotalAndTaxes(string total)
        {
            this.total = total;

            return this;
        }

        public void Finish()
        {
            var subtotalValue = Driver.Instance.FindElement(By.ClassName("summary_subtotal_label")).Text.Split('$')[1];
            var taxValue = Driver.Instance.FindElement(By.ClassName("summary_tax_label")).Text.Split('$')[1];
            var totalValue = Driver.Instance.FindElement(By.ClassName("summary_total_label")).Text.Split('$')[1];

            bool isSubtotalCorrect = true;
            bool isTaxCorrect = true;
            bool isTotalCorrect = true;

            if(!subtotalValue.Equals(subtotal))
            {
                isSubtotalCorrect = false;
            }

            if(!taxValue.Equals(tax))
            {
                isTaxCorrect = false;
            }

            if(!totalValue.Equals(total))
            {
                isTotalCorrect = false;
            }

            try
            {
                Assert.IsTrue(isSubtotalCorrect, "Subtotal is not showing correct value");
            } catch(Exception e)
            {
                Console.WriteLine("Subtotal error message: " + e.Message);
            }

            try
            {
                Assert.IsTrue(isTaxCorrect, "Tax is not showing correct value");
            }
            catch (Exception e)
            {
                Console.WriteLine("Tax error message: " + e.Message);
            }

            try
            {
                Assert.IsTrue(isTotalCorrect, "Total is not showing correct value");
            }
            catch (Exception e)
            {
                Console.WriteLine("Total error message: " + e.Message);
            }

            Driver.Instance.FindElement(By.ClassName("cart_button")).Click();
        }
    }
}
