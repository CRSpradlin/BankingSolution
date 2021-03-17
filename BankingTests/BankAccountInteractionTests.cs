using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class BankAccountInteractionTests
    {
        [Fact]
        public void DepositUsesTheBonusCalculator()
        {
            var stubbedBonusCaculator = new StubbedBonusCalculator();
            var account = new BankAccount(stubbedBonusCaculator);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 10M;

            stubbedBonusCaculator.AmountToReturn = 42;
            stubbedBonusCaculator.ExpectedAmountOfDeposit = amountToDeposit;
            stubbedBonusCaculator.ExpectedBalance = openingBalance;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + 42, account.GetBalance());
        }
    }

    public class StubbedBonusCalculator : ICanCalculateBankAccountBonuses
    {
        public decimal ExpectedBalance;
        public decimal ExpectedAmountOfDeposit;
        public decimal AmountToReturn;
        
        public decimal For(decimal balance, decimal amountToDeposit)
        {
            if(balance == ExpectedBalance && amountToDeposit == ExpectedAmountOfDeposit)
            {
                return AmountToReturn;
            } else
            {
                return -10; // something dumb, to make sure everything is working right
            }
        }
    }
}
