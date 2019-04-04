using OpenQA.Selenium;

namespace automationTrueProject
{
    public class LoginCommand
    {
        private string password;
        private readonly string userName;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;

            return this;
        }

        public void Login()
        {
            var userNameInput = Driver.Instance.FindElement(By.Id("user-name"));
            userNameInput.SendKeys(userName);

            var passwordInput = Driver.Instance.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);

            var loginBtn = Driver.Instance.FindElement(By.ClassName("btn_action"));
            loginBtn.Click();

        }
    }
}
