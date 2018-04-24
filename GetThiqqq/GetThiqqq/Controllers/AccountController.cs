using System;
using Microsoft.AspNetCore.Mvc;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using GetThiqqq.Services;

namespace GetThiqqq.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public AccountController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserProfile(UserAccountViewModel userAccountViewModel)
        {
            var loginAccountViewModel = new LoginAccountViewModel
            {
                Password = userAccountViewModel.UserPassword,
                UserId = userAccountViewModel.UserId,
                Username = userAccountViewModel.Username
            };
            var userAccount = loginAccountViewModel.UserId == 0 ? _userAccountRepository.LoginAccount(loginAccountViewModel) : _userAccountRepository.GetUserById((int)TempData["Id"]);
            var userProfileViewModel = new UserAccountViewModel
            {
                UserId = userAccount.Id,
                UserEmail = userAccount.EmailAddress,
                UserPassword = userAccount.Password,
                Username = userAccount.Username,
                Address = ""
            };
            Response.Cookies.Append("userAccountId", userAccount.Id.ToString());
            return View(userProfileViewModel);
        }


        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult SubmitAccount(CreateAccountViewModel createAccountViewModel)
        {
            if (_userAccountRepository.IsUsernameTaken(createAccountViewModel.Username) ||
                _userAccountRepository.IsEmailTaken(createAccountViewModel.EmailAddress)) 
            {
                return RedirectToAction("CreateAccount");
            }

            if (_userAccountRepository.AddNewAccount(createAccountViewModel))
                return View();
            else
                return RedirectToAction("CreateAccount");
        }
    }
}
