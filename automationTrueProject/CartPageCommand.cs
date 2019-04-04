using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace automationTrueProject
{
    public class CartPageCommand
    {

        public CartPageCommand VerifyItemPrice(string itemName, string itemPrice)
        {
            var cartItems = Driver.Instance.FindElements(By.ClassName("cart_item"));
            bool isItemOnlist = false;
            bool isPriceCorrect = true;

            foreach(var cartItem in cartItems)
            {
                var cartItemName = cartItem.FindElement(By.ClassName("inventory_item_name")).Text;
                var cartItemPrice = cartItem.FindElement(By.ClassName("inventory_item_price")).Text;

                if (cartItemName.Equals(itemName))
                {
                    isItemOnlist = true;
                    if (!cartItemPrice.Equals(itemPrice))
                    {
                        isPriceCorrect = false;
                        break;
                    }

                    break;
                }
            }

            try
            {
                Assert.IsTrue(isItemOnlist, "Item is not on list");
            } catch(Exception e)
            {
                Console.WriteLine("Error message for Item is not in list: " + e.Message);
            }

            try
            {
                Assert.IsTrue(isPriceCorrect, "Item doesn't have correct Price");
            } catch(Exception e)
            {
                Console.WriteLine("Error message for Item doesn't show correct price in list: " + e.Message);
            }

            return this;
        }

        public void Checkout()
        {
            Driver.Instance.FindElement(By.ClassName("checkout_button")).Click();
        }

    }
}
