using OpenQA.Selenium;

namespace automationTrueProject
{
    public class CheckoutCompletePage
    {
        public static bool IsAt
        {
            get
            {
                var completeHeaderLabel = Driver.Instance.FindElements(By.ClassName("complete-header")).ToString();

                if (completeHeaderLabel.Equals("THANK YOU FOR YOUR ORDER"))
                {
                    return false;
                }

                return true;
            }
        }

        public static bool IsOrderCompleted(string message)
        {
            var completeHeaderLabel = Driver.Instance.FindElements(By.ClassName("complete-header")).ToString();

            if (completeHeaderLabel.Equals(message))
            {
                return false;
            }

            return true;
        }
    }
}
