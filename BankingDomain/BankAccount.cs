using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable "Field"

        //Creating an interface which creates a "contract" that states it can calculate bonuses
        //An Interface is a way to link functionality:
        //  - The IEnumerable interface "Signs Off" that whichever class implements me, is Enumerable
        //  - It is a promise that this object of _bankAccountBonusCaculator will be able to calculate bonuses
        private ICanCalculateBankAccountBonuses _bankAccountBonusCalculator;

        public BankAccount(ICanCalculateBankAccountBonuses bankAccountBonusCalculator)
        {
            _bankAccountBonusCalculator = bankAccountBonusCalculator;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            //Small client defined interface
            //Write the code I wish I had
            decimal bonus = _bankAccountBonusCalculator.For(_balance, amountToDeposit);

            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}