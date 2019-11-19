using samiesbank.Models;
using System;
using System.Collections.Generic;
using Xunit;


namespace samiesbank.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WithdrawalOverDraft()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Samie",
                    CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 1,
                            Balance = 700M
                        }
                    }
                }
            };

            BankRepository.AddCustomers(customers);
            decimal amount = 900M;
            decimal expected = 700M;

            var actualAccount = BankRepository.Withdrawal(1, amount);

            Assert.Equal(expected, actualAccount.Balance, 2);
        }



        [Fact]
        public void Withdrawal_CantWithdrawFromNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Samie",
                    CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 500M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 100M;
            string expected = BankRepository.AccountDoesNotExist;

            // Act
            BankRepository.Withdrawal(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }


        [Fact]
        public void Deposit_CanMakeBasicDeposit()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Samie",
                   CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 4,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            decimal expected = 800M;

            // Act
            var account = BankRepository.Deposit(4, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositNegativeAmount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Robert",
                    CustomerId = 2,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 5,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = -200M;
            decimal expected = 600M;

            // Act
            var account = BankRepository.Deposit(5, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositToNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Michael",
                    CustomerId = 3,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            string expected = BankRepository.AccountDoesNotExist;

            // Act
            BankRepository.Deposit(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }
    }
}
