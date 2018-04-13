using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using GetThiqqq.Services;
using NUnit.Framework;

namespace GetThiqqUnitTests.RepositoryUnitTest
{
    [TestFixture]
    public class UserRepositoryUnitTests
    {
        private readonly UserAccountRepository _repository = new UserAccountRepository();

        [Test]
        public void Should_confirm_email_is_taken()
        {
            Assert.IsTrue(_repository.IsEmailTaken("jfh79@case.edu"));
        }

        [Test]
        public void Should_confirm_email_is_available()
        {
            Assert.IsFalse(_repository.IsEmailTaken("test"));
        }

        [Test]
        public void Should_confirm_username_is_taken()
        {
            Assert.IsTrue(_repository.IsUsernameTaken("jyz6"));
        }

        [Test]
        public void Should_confirm_username_is_available()
        {
            Assert.IsFalse(_repository.IsUsernameTaken("notAUsername"));
        }

        [Test]
        public void Should_get_user_by_Id()
        {
            var myUser = _repository.GetUserById(1);
            Assert.AreEqual("jfh79", myUser.Username);
            Assert.AreEqual("1234", myUser.Password);
            Assert.AreEqual("jfh79@case.edu", myUser.EmailAddress);
        }

        [Test]
        public void Should_log_in_user()
        {
            var loginViewModel = new LoginAccountViewModel
            {
                Username = "jfh79",
                Password = "1234"
            };
            var userAccount = new UserAccount
            {
                Username = "jfh79",
                Password = "1234",
                EmailAddress = "jfh79@case.edu"
            };

            var testUser = _repository.LoginAccount(loginViewModel);
            Assert.AreEqual(loginViewModel.Username, testUser.Username);
            Assert.AreEqual("jfh79@case.edu", testUser.EmailAddress);
        }

        [Test]
        public void Should_not_log_in_user_if_user_doesnt_exist()
        {
            var loginViewModel = new LoginAccountViewModel
            {
                Username = "not",
                Password = "account"
            };

            var testUser = _repository.LoginAccount(loginViewModel);
            Assert.Null(testUser);
        }

        [Test]
        public void Should_create_new_account()
        {
            var createAccountViewModel = new CreateAccountViewModel
            {
                Username = "UnitTest",
                Password = "UnitTest",
                EmailAddress = "test@unit.com"
            };

            Assert.IsTrue(_repository.AddNewAccount(createAccountViewModel));
            
        }
    }
}
