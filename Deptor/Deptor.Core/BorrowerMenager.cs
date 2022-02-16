namespace Deptor.Core
{
    public class BorrowerMenager
    {
        private List<Borrower> Borrowers { get; set; }

        private string FileName { get; set; } = "borrowers.txt";



        public BorrowerMenager()
        {
            Borrowers = new List<Borrower>();

            if (!File.Exists(FileName))
            {
                return;
            }

            var fileLines = File.ReadAllLines(FileName);

            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (decimal.TryParse(lineItems[1], out var amountInDecimal))
                {
                    AddBorrower(lineItems[0], amountInDecimal, false);
                }
            }
        }
        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        {
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount,
            };
            
                Borrowers.Add(borrower);

            if (shouldSaveToFile)
            {
                var borrowerToSave = new List<string>();

                foreach (var deptor in Borrowers)
                {
                    borrowerToSave.Add(deptor.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowerToSave);
            }
              
        }
        
        public void DeleteBorrower(string name, bool shouldSaveToFile = true)
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }
            }

            if (shouldSaveToFile)
            {
                var borrowerToSave = new List<string>();

                foreach (var borrower in Borrowers)
                {
                    borrowerToSave.Add(borrower.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowerToSave);
            }

        }

        public void PartDeptCancelation(string name, decimal amount, bool shouldSaveToFile = true)
        {
            if (!Borrowers.Exists(borrower => borrower.Name == name))
            {
                Console.WriteLine("Nie ma takiego dłużnika na liście.");
            }
            else
            {
                foreach (var borrower in Borrowers)   
                {
                    if (borrower.Name == name)
                    {
                        borrower.PartDeptCancelation(amount);
                        if (borrower.Amount == 0)
                        {
                            DeleteBorrower(name);
                            Console.WriteLine("Dłużnik spłacił cały swój dług i został usunięty z listy dłużników.");
                        }
                        else if (borrower.Amount > 0)
                        {
                            Console.WriteLine($"Dłużnik {borrower.Name} ma jeszcze do spłacenia {borrower.Amount} zł");
                            if (shouldSaveToFile)
                            {
                                var borrowerToSave = new List<string>();

                                foreach (var deptor in Borrowers)
                                {
                                    borrowerToSave.Add(deptor.ToString());
                                }
                                File.Delete(FileName);
                                File.WriteAllLines(FileName, borrowerToSave);
                            }
                        }
                        else
                        {
                            var excessPayment = -(borrower.Amount - amount);
                            Console.WriteLine($"Dłużnik oddał za dużo. należy mu zwrócić {excessPayment} zł");
                        }
                    }
                }
            }
        }

        public List<string> ListBorrowes()
        {
            var borrowerStrings = new List<string>();
            var indexer = 1;

            foreach (var borrower in Borrowers)
            {
                var borrowerString = indexer + ". " + borrower.Name + " - " + borrower.Amount + " zł";
                indexer++;

                borrowerStrings.Add(borrowerString);
            }
            return borrowerStrings;
        }
    }
}
