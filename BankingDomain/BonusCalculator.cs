using System;

namespace BankingDomain
{
    public class BonusCalculator : ICanCalculateBankAccountBonuses
    {
        public BonusCalculator()
        {
        }

        public decimal CalculateBonusForBankAccountDeposits(decimal balance, decimal amountOfDeposit)
        {
            return balance >= 4000 ? amountOfDeposit * .10M : 0;
        }

        //If you sign the contract of the interface, you need to implement "For"
        public decimal For(decimal balance, decimal amountToDeposit)
        {
            return CalculateBonusForBankAccountDeposits(balance, amountToDeposit);
        }
    }
}