namespace DayOfTheWeekApp
{
    class Program
    {
        static void Main(String[] args)
        {
            var guesser = new DayGuesser();
            guesser.IntroduceTheApplication(); 
            guesser.AskUserForTheDayOfBirth();
            guesser.CalculateDayOfTheWeek();
            guesser.PrintDayOfTheWeek();
        }
    }
}