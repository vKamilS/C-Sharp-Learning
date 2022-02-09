namespace DayOfTheWeekApp.Core
{
    public class DayCalculator
    {
        public DayOfTheWeek CalculateDayOfTheWeek(DateTimeOffset date)
        {
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;  

            var listOfParameters = new List <int> { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            
            /*if (month < 3)
            {
                year -= 1;
            }*/
            year -= (month < 3) ? 1 : 0;

            var calculatedValue =  (year + year / 4 - year / 100 + year / 400 + listOfParameters[month - 1] + day) % 7;
         
            return (DayOfTheWeek)(calculatedValue - 1);
        }
    }
}