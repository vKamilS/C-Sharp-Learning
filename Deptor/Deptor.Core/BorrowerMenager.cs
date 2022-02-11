namespace Deptor.Core
{
    public class BorrowerMenager
    {
        private List<Borrower> Borrowers { get; set; }

        public BorrowerMenager()
        {
            Borrowers = new List<Borrower>();
        }
        public void AddBorrower(string name, decimal amount)
        {
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount,
            };
            Borrowers.Add(borrower);
              
        }

        public void DeleteBorrower(string name)
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    return;
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
