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
        private readonly IForumPostRepository _forumPostRepository;

        public AccountController(IUserAccountRepository userAccountRepository, IForumPostRepository forumPostRepository)
        {
            _userAccountRepository = userAccountRepository;
            _forumPostRepository = forumPostRepository;
        }

        public IActionResult Login()
        {
            if(Request.Cookies["userAccountId"] == null)
                return View();
            var userAccount = _userAccountRepository.GetUserById(int.Parse(Request.Cookies["userAccountId"]));
            var userAccountViewModel = new UserAccountViewModel
            {
                UserId = userAccount.Id,
                UserPassword = userAccount.Password,
                UserEmail = userAccount.EmailAddress,
                Username = userAccount.Username
            };
            return RedirectToAction("UserProfile", userAccountViewModel);
        }

        public IActionResult UserProfile(UserAccountViewModel userAccountViewModel)
        {
            var loginAccountViewModel = new LoginAccountViewModel
            {
                Password = userAccountViewModel.UserPassword,
                UserId = userAccountViewModel.UserId,
                Username = userAccountViewModel.Username
            };
            var userAccount = loginAccountViewModel.UserId == 0 ? _userAccountRepository.LoginAccount(loginAccountViewModel) : _userAccountRepository.GetUserById(int.Parse(Request.Cookies["userAccountId"]));
            var userProfileViewModel = new UserAccountViewModel
            {
                UserId = userAccount.Id,
                UserEmail = userAccount.EmailAddress,
                UserPassword = userAccount.Password,
                Username = userAccount.Username,
                Address = "",
                UserPosts = _forumPostRepository.GetForumPostByTopicId(userAccount.Id)
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
            return RedirectToAction("CreateAccount");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("userAccountId");
            return RedirectToAction("Index", "Home");
        }
    }
}
