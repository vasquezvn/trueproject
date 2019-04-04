using System;

namespace automationTrueProject
{
    public class CheckOutStepOnePage
    {
        public static CheckOutStepOnePageCommand CheckoutAs(String name)
        {
            return new CheckOutStepOnePageCommand(name);
        }
    }
}
