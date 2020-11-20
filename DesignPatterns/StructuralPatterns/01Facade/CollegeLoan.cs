using System;

namespace Facade
{
    public class CollegeLoan
    {
        private Bank bank;
        private Loan loan;
        private Credit credit;

        public CollegeLoan()
        {
            this.bank = new Bank();
            this.loan = new Loan();
            this.credit = new Credit();
        }

        public bool IsEligible(Student stud, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
                stud.Name, amount);

            bool eligible = true;

            // Verify creditworthyness of applicant
            if (!bank.HasSufficientSavings(stud, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(stud))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(stud))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}