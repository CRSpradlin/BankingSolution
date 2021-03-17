using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class GoldCustomerTests
    {

        [Theory]
        [InlineData(100,10)]
        public void GetABonusOnDeposites(decimal amountToDeposit, decimal expectedBonus)
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            account.AccountType = AccountTypes.Gold;

            account.Deposit(amountToDeposit);

            var expected = openingBalance + amountToDeposit + expectedBonus;
            Assert.Equal(expected, account.GetBalance());
        }
    }
}
