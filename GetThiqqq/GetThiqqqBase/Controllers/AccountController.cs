using Microsoft.AspNetCore.Mvc;
using GetThiqqq;
using GetThiqqqBase.Models;

namespace GetThiqqqBase.Controllers
{
    public class AccountController : Controller
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

            return View();
        }
    }
}
