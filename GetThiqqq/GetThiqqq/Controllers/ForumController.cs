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

        public IActionResult CreatePost(ViewModelBase viewModelBase)
        {
            var createPostViewModel = new CreatePostViewModel
            {
                UserId = viewModelBase.UserId
            };
            TempData["Id"] = 0;
            return View(createPostViewModel);
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

        public IActionResult EditPost(ViewModelBase viewModelBase)
        {
            var editPostViewModel = new CreatePostViewModel
            {
                UserId = viewModelBase.UserId
            };
            
            return View(editPostViewModel);
        }

        public IActionResult CreateTopic(ViewModelBase viewModelBase)
        {
            var createTopicViewModel = new CreateTopicViewModel
            {
                UserId = viewModelBase.UserId
            };
            TempData["Id"] = 0;
            return View(createTopicViewModel);
        }

        public IActionResult SubmitTopic(CreateTopicViewModel createTopicViewModel)
        {
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

        public IActionResult ForumHome(ViewModelBase viewModelBase)
        { 
            return View();
        }

        public IActionResult ForumTopic(ForumTopicViewModel forumTopicViewModel)
        {
            return View(forumTopicViewModel);
        }
    }
}
