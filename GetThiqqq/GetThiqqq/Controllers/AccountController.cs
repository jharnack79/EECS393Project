using Microsoft.AspNetCore.Mvc;
using GetThiqqq;
using GetThiqqq.Models;

namespace GetThiqqq.Controllers
{
    public class AccountController 
    {
        public IUserAccount _userAccount;

        public AccountController(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult CreateAccount(UserAccountViewModel userAccountViewModel)
        {

            if (_userAccount.IsEmailAddressRegistered(userAccountViewModel.UserEmail) && _userAccount.IsPasswordSecure(userAccountViewModel.UserPassword))
            {
                RedirectToAction("CreateAccount");
            }
            _userAccount.CreateAccount(userAccountViewModel);
            return View();
        }
    }
}
