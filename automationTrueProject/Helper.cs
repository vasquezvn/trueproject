using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace automationTrueProject
{
    public class Helper
    {
        public static void chooseValueDropdownList(IWebElement dropdownlist, String value)
        {
            var selectElement = new SelectElement(dropdownlist);
            selectElement.SelectByText(value);

        }
    }
}
