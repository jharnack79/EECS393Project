using GetThiqqq.Models;
using GetThiqqq.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GetThiqqq.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumPostRepository _forumPostRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IForumTopicRepository _forumTopicRepository;

        public ForumController(IForumPostRepository forumPostRepository, IForumTopicRepository forumTopicRepository, IUserAccountRepository userAccountRepository)
        {
            _forumPostRepository = forumPostRepository;
            _userAccountRepository = userAccountRepository;
            _forumTopicRepository = forumTopicRepository;
        }

        public IActionResult CreatePost()
        {
            if (Request.Cookies["userAccountId"] != null)
            {
                var createPostViewModel = new CreatePostViewModel
                {
                    UserId = int.Parse(Request.Cookies["userAccountId"])
                };
                return View(createPostViewModel);
            }

            return RedirectToAction("ForumHome");

        }

        public IActionResult SubmitPost(CreatePostViewModel createPostViewModel)
        {
            var newPost = _forumPostRepository.CreateForumPost(createPostViewModel);
            var userAccount = _userAccountRepository.GetUserById(createPostViewModel.UserId);
            var forumTopic = _forumTopicRepository.GetForumTopicById(createPostViewModel.TopicId);
            var forumTopicViewModel = new ForumTopicViewModel
            {
                UserAccount = userAccount,
                ForumTopic = forumTopic
            };

            return RedirectToAction("ForumTopic", forumTopicViewModel);
        }

        public IActionResult EditPost()
        {
            var editPostViewModel = new CreatePostViewModel
            {
                UserId = int.Parse(Request.Cookies["userAccountId"])
            };
 
            return View(editPostViewModel);
        }

        public IActionResult CreateTopic()
        {
            if (Request.Cookies["userAccountId"] == null)
                return RedirectToAction("ForumHome");
            var createTopicViewModel = new CreateTopicViewModel
            {
                UserId = int.Parse(Request.Cookies["userAccountId"])
            };
            return View(createTopicViewModel);
        }

        public IActionResult SubmitTopic(CreateTopicViewModel createTopicViewModel)
        {
            createTopicViewModel.UserId = int.Parse(Request.Cookies["userAccountId"]);
            var newTopic = _forumTopicRepository.CreateNewForumTopic(createTopicViewModel);
            if (newTopic == null)
            {
                return RedirectToAction("CreateTopic");
            }
            var userAccount = _userAccountRepository.GetUserById(createTopicViewModel.UserId);
            var forumTopicViewModel = new ForumTopicViewModel
            {
                ForumTopic = newTopic,
                UserAccount = userAccount
            };

            return RedirectToAction("ForumTopic", forumTopicViewModel);
        }

        public IActionResult ForumHome()
        { 
            var forumHomeViewModel = new ForumHomeViewModel
            {
                Topics = _forumTopicRepository.GetAllForumTopics()
            };
            return View(forumHomeViewModel);
        }

        public IActionResult ViewTopic(int id)
        {
            return RedirectToAction("ForumTopic", null);
        }

        public IActionResult ForumTopic(ForumTopicViewModel forumTopicViewModel)
        {
            var userAccount = _userAccountRepository.GetUserById(int.Parse(Request.Cookies["userAccountId"]));
            var fourmTopic = _forumTopicRepository.GetForumTopicById(1);
            forumTopicViewModel.UserAccount = userAccount;
            forumTopicViewModel.ForumTopic = fourmTopic;
            return View(forumTopicViewModel);
        }
    }
}
