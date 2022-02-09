using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfTheWeekApp.Core
{
    public static class EnumExtensions
    {
        public static string ToPolishString(this DayOfTheWeek dayOfTheWeek)
        {
            switch (dayOfTheWeek)
            {
                case DayOfTheWeek.Monday:
                    return "Poniedziałek";
                case DayOfTheWeek.Thusday:
                    return "Wtorek";
                case DayOfTheWeek.Wednesday:
                    return "Środa";
                case DayOfTheWeek.Thursday:
                    return "Czwartek";
                case DayOfTheWeek.Friday:
                    return "Piątek";
                case DayOfTheWeek.Saturday:
                    return "Sobota";
                case DayOfTheWeek.Sunday:
                    return "Niedziela";

                    default:
                    return "Błąd";

            }
        }
    }
}
