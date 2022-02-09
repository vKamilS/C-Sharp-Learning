using DayOfTheWeekApp.Core;

namespace DayOfTheWeekApp
{
    internal class DayGuesser
    {
        public DayCalculator Calculator { get; set; }

        public DateTimeOffset UserDateOfBirth { get; set; }

        public DayOfTheWeek UserDayOfTheWeek { get; set; }

        public void IntroduceTheApplication()
        {
            Console.WriteLine("To jest aplikacja do obliczania dnia tygodnia, w którym się urodziłeś");
            Calculator = new DayCalculator();
        }
        
        public void AskUserForTheDayOfBirth()
        {
            Console.WriteLine("Podaj datę swoich urodzin w formacie mm/dd/yyyy");
            var userDate = Console.ReadLine();

            var succeded  = DateTimeOffset.TryParse(userDate, out var date);
            if (succeded)
             {
                UserDateOfBirth = date;
                return;
             }

            Console.WriteLine("Podany format daty był zły. Proszę podaj datę w formacie mm/dd/yyyy");
            AskUserForTheDayOfBirth();
        }

        public void CalculateDayOfTheWeek()
        {
            if (UserDateOfBirth == null)
            {
                Console.WriteLine("Próbowano obliczyć dzień tygodnia bez podania daty urodzenia");
                return;
            }

            UserDayOfTheWeek = Calculator.CalculateDayOfTheWeek(UserDateOfBirth);
        }

        public void PrintDayOfTheWeek()
        {
            Console.WriteLine("Dzień tygodnia, w którym się urodziłeś/aś to " + UserDayOfTheWeek.ToPolishString());
        }
    }
}
