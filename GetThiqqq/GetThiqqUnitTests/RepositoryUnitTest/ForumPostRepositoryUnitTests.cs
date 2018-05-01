using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using NUnit.Framework;

namespace GetThiqqUnitTests.RepositoryUnitTest
{
    [TestFixture]
    public class ForumPostRepositoryUnitTests
    {
        private static readonly  UserAccountRepository _userAccountRepository;
        private readonly ForumPostRepository _repository = new ForumPostRepository(_userAccountRepository);

        [Test]
        public void Should_get_posts_for_topic()
        {
            var forumPosts = _repository.GetForumPostByTopicId(27);
            Assert.NotNull(forumPosts);

        }

        [Test]
        public void Should_get_null_when_no_posts_for_topic()
        {
            var forumPosts = _repository.GetForumPostByTopicId(-1);
            Assert.Zero(forumPosts.Count);
        }

        [Test]
        public void Should_create_test_post()
        {
            var createTopicViewModel = new CreatePostViewModel
            {
                TopicId = 0,
                PostText = "UnitTest",
                UserId = 0
            };
            var forumPost = _repository.CreateForumPost(createTopicViewModel);
            Assert.AreEqual("UnitTest", forumPost.PostText);
        }
    }
}
