using GetThiqqq.Models;
using GetThiqqq.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace GetThiqqq.Services
{
    public interface IUserAccount
    {
        bool CreateAccount(CreateAccountViewModel userAccountViewModel);

        bool IsUsernameTaken(string userName);

        bool IsPasswordSecure(string password);

        bool IsEmailAddressRegistered(string emailAddress);
    }

    public class UserAccount : IUserAccount
    {
        public IUserAccountRepository _userAccountRepository;

        public UserAccount(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        //Will create account and add info to database, if successful, will redirect to success page
        //If return false, will throw error message on page and get user to re-enter info
        public bool CreateAccount(CreateAccountViewModel userAccountViewModel)
        {
            _userAccountRepository.AddNewAccount(userAccountViewModel);
            return true;
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
