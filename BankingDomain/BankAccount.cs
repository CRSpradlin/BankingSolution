using System;

namespace BankingDomain
{
    public enum AccountTypes { Standard, Gold }
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable AKA: "Field"
        public AccountTypes AccountType = AccountTypes.Standard;

        public BankAccount()
        {
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = 0;
            if (AccountType == AccountTypes.Gold)
            {
                bonus = amountToDeposit * .10M;
            }
            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}