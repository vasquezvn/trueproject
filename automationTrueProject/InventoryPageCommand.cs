using OpenQA.Selenium;
using System;

namespace automationTrueProject
{
    public class InventoryPageCommand
    {
        private string sortCriteria;

        public InventoryPageCommand(String sortCriteria)
        {
            this.sortCriteria = sortCriteria;

            var productSortDropDownList = Driver.Instance.FindElement(By.ClassName("product_sort_container"));
            Helper.chooseValueDropdownList(productSortDropDownList, sortCriteria);
        }

        public InventoryPageCommand AddItemToCart(string itemName)
        {
            var inventoryItems = Driver.Instance.FindElements(By.ClassName("inventory_item"));

            foreach (var inventoryItem in inventoryItems)
            {
                var inventoryItemName = inventoryItem.FindElement(By.ClassName("inventory_item_name")).Text;

                if (inventoryItemName.Equals(itemName))
                {
                    inventoryItem.FindElement(By.ClassName("btn_primary")).Click();
                    break;
                }
            }

            return this;
        }

        public void GoToShoopingCart()
        {
            Driver.Instance.FindElement(By.ClassName("shopping_cart_link")).Click();
        }


    }
}
