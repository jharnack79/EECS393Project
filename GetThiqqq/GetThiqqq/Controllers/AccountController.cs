using Microsoft.AspNetCore.Mvc;
using GetThiqqq.Models;
using GetThiqqq.Services;

namespace GetThiqqq.Controllers
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

        public IActionResult CreateAccount(CreateAccountViewModel createAccountViewModel)
        {

            if (_userAccount.IsEmailAddressRegistered(createAccountViewModel.EmailAddress) && _userAccount.IsPasswordSecure(createAccountViewModel.Password))
            {
                RedirectToAction("CreateAccount");
            }
            _userAccount.CreateAccount(createAccountViewModel);
            return View();
        }
    }
}
