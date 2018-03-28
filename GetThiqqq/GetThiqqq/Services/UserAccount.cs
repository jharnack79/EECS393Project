using GetThiqqq.Models;
using GetThiqqq.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace GetThiqqq.Services
{
    public interface IUserAccount
    {
        bool IsPasswordSecure(string password);

        bool IsEmailAddressRegistered(string emailAddress);
    }

    public class UserAccount : IUserAccount
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

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
