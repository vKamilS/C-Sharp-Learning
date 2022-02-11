using Deptor.Core;

namespace Deptor
{
    public class DeptorApp
    {
        public BorrowerMenager BorrowerMenager { get; set; } = new BorrowerMenager();
        
        public void IntroduceDeptorApp()
        {
            Console.WriteLine("Hej witaj w aplikacji dłużnik. Zapisuj tu listę swoich dłużników, tak abyś wiedział ile kasy kto Ci wisi.");
        }

        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodac do listy:");
            var userName = Console.ReadLine();
            
            Console.WriteLine("Podaj kwotę długu:");
            var userAmount = Console.ReadLine();
            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Podano niepoprawną kwotę");
                Console.WriteLine("Podaj kwotę długu:");
                userAmount = Console.ReadLine();
            }
            
            BorrowerMenager.AddBorrower(userName, amountInDecimal);    
        }

        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć z listy:");
            var userName = Console.ReadLine();

            BorrowerMenager.DeleteBorrower(userName);

            Console.WriteLine("Udało się usunąć dłużnika.");
        }

        public void ListAllBorrower()
        {
            Console.WriteLine("Oto lista Twoich dłużników:");

            foreach(var borrower in BorrowerMenager.ListBorrowes())
            {
                Console.WriteLine(borrower);
            }
        }

        public void AskForAction()
        {
            var userInput = default(string);    

            while (userInput != "exit")
            {
                Console.WriteLine("Podaj czynność, którą chcesz wykonać:");
                Console.WriteLine("add - dodawanie dłużnika");
                Console.WriteLine("del - usuwanie dłużnika");
                Console.WriteLine("list - wypisywanie listy dłużników");
                Console.WriteLine("exit - wyjście z programu");


                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "list":
                        ListAllBorrower();
                        break;


                    default:
                        Console.WriteLine("Zostało wpisane niepoprawne polecenie.");
                        break;
                }
            }
        }

    }
}
