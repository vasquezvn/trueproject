using OpenQA.Selenium;

namespace automationTrueProject
{
    public class InventoryPage
    {
        public static bool IsAt
        {
            get
            {
                var productLabel = Driver.Instance.FindElements(By.ClassName("product_label"));

                if(productLabel.Count == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public static InventoryPageCommand OrderProductBy(string sortCriteria)
        {
            return new InventoryPageCommand(sortCriteria);
        }


    }
}
