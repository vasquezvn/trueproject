using OpenQA.Selenium;

namespace automationTrueProject
{
    public class CheckOutStepOnePageCommand
    {
        private string name;
        private string lastName;
        private string zipCode;

        public CheckOutStepOnePageCommand(string name)
        {
            this.name = name;
        }

        public CheckOutStepOnePageCommand WithLastName(string lastname)
        {
            this.lastName = lastname;

            return this;
        }

        public CheckOutStepOnePageCommand WithCodeZip( string zipCode)
        {
            this.zipCode = zipCode;

            return this;
        }

        public void Continue()
        {
            Driver.Instance.FindElement(By.Id("first-name")).SendKeys(name);
            Driver.Instance.FindElement(By.Id("last-name")).SendKeys(lastName);
            Driver.Instance.FindElement(By.Id("postal-code")).SendKeys(zipCode);

            Driver.Instance.FindElement(By.ClassName("cart_button")).Click();
        }


    }
}
