namespace FinanceKnowHow.Controllers
{
    public class DateSuffix
    {
        public string GetSuffix(string day)
        {
            // Determine the suffix
            string suffix = "";
            int numericDay = int.Parse(day);
            if (numericDay >= 11 && numericDay <= 13)
            {
                suffix = "th";
            }
            else
            {
                switch (numericDay % 10)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }
            return suffix;
        }
    }
}
