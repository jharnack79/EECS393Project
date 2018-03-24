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

        public IActionResult SubmitAccount(CreateAccountViewModel createAccountViewModel)
        {

            if (_userAccount.IsEmailAddressRegistered(createAccountViewModel.EmailAddress) && _userAccount.IsPasswordSecure(createAccountViewModel.Password))
            {
                return RedirectToAction("CreateAccount");
            }
            if (_userAccount.CreateAccount(createAccountViewModel))
                return View();
            else
                return RedirectToAction("CreateAccount");
        }
    }
}
