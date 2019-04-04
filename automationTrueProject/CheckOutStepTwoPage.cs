namespace automationTrueProject
{
    public class CheckOutStepTwoPage
    {
        public static CheckOutStepTwoPageCommand VerifyTotal(string total)
        {
            return new CheckOutStepTwoPageCommand(total);
        }
    }
}
