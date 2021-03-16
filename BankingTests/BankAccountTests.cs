
using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
          
            // Given
            var account = new BankAccount();
            // When
            decimal balance = account.GetBalance();
            // Then
            Assert.Equal(5000M, balance);
        }

        [Fact]
        public void DepositsIncreaseTheBalance()
        {
            // WTCYWYH
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 42M;
            // When
            account.Deposit(amountToDeposit);
            // Then
            Assert.Equal(
                openingBalance + amountToDeposit,
                account.GetBalance()
                );
        }

        [Fact]
        public void WithdrawalsDecreaseTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 42M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());
        }
    }
}
