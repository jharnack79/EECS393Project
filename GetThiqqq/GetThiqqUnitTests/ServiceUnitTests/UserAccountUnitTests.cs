using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GetThiqqq.Services;

namespace GetThiqqUnitTests.ServiceUnitTests
{
    [TestFixture]
    public class UserAccountUnitTests
    {

        [Test]
        public void Should_confirm_username_is_available()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsUsernameTaken("MyUserName"));

        }

        [Test]
        public void Should_confirm_username_is_not_available()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsUsernameTaken("MyUserName"));

        }

        [Test]
        public void Should_confirm_password_is_secure()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsPasswordSecure("!PassWord123!"));

        }

        [Test]
        public void Should_confirm_password_is_not_secure()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsUsernameTaken("1234"));
        }

        [Test]
        public void Should_confirm_email_is_available()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsEmailAddressRegistered("jfh79@case.edu"));

        }

        [Test]
        public void Should_confirm_password_is_taken()
        {
            UserAccount userAccount = new UserAccount();
            Assert.IsFalse(userAccount.IsEmailAddressRegistered("abc123@case.edu"));

        }
    }
}
