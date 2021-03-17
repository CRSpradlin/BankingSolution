
using BankingDomain;
using Moq;
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
        private decimal _balance;
        BankAccount _account;

        public BankAccountTests()
        {
            //Just created a blank Mock because the object simply returns the default decimal value of 0
            _account = new BankAccount(
                new Mock<ICanCalculateBankAccountBonuses>().Object,
                new Mock<INotifyTheFeds>().Object
                );
            _balance = _account.GetBalance();
        }

        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            Assert.Equal(5000M, _balance);
        }

        [Fact]
        public void DepositsIncreaseTheBalance()
        {
            // WTCYWYH
            // Given
            var balance = _account.GetBalance();
            var amountToDeposit = 42M;
            // When
            _account.Deposit(amountToDeposit);
            // Then
            Assert.Equal(
                balance + amountToDeposit,
                _account.GetBalance()
                );
        }

        [Fact]
        public void WithdrawalsDecreaseTheBalance()
        {
            var amountToWithdraw = 42M;

            _account.Withdraw(amountToWithdraw);

            Assert.Equal(
                _balance - amountToWithdraw,
                _account.GetBalance());
        }
    }
}
