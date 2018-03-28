using Microsoft.AspNetCore.Mvc;
using GetThiqqq.Models;
using GetThiqqq.Repository;

namespace GetThiqqq.Controllers
{
    public class AccountController : Controller
    {
        public IUserAccountRepository _userAccountRepository;

        public AccountController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserProfile(LoginAccountViewModel loginAccountViewModel)
        {
            var userAccount = _userAccountRepository.LoginAccount(loginAccountViewModel);
            var userProfileViewModel = new UserAccountViewModel(userAccount);
            return View(userProfileViewModel);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult SubmitAccount(CreateAccountViewModel createAccountViewModel)
        {
            if (false)//add repo methods to confirm user email and username not already in use
            {
                //return RedirectToAction("CreateAccount");
            }
            if (_userAccountRepository.AddNewAccount(createAccountViewModel))
                return View();
            else
                return RedirectToAction("CreateAccount");
        }
    }
}
