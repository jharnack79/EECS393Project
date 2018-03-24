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
    }
}
