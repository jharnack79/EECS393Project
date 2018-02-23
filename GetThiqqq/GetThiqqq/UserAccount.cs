using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq
{
    public interface IUserAccount
    {
        UserAccount CreateAccount(string userName, string Password, string EmailAddress);

        bool IsUsernameTaken(string userName);

        bool IsPasswordSecure(string password);

        bool IsEmailAddressRegistered(string emailAddress);
    }

    public class UserAccount : IUserAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public UserAccount CreateAccount(string userName, string password, string emailAddress)
        {
            //Add information to DB
            //Get User account ID and post that to each page
            //Send verification email
            return null;
        }

        public bool IsUsernameTaken(string userName)
        {
            return false;
        }

        public bool IsPasswordSecure(string password)
        {
            return false;
        }

        public bool IsEmailAddressRegistered(string emailAddress)
        {
            return false; 
        }
    }
}
