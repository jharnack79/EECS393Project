﻿using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GetThiqqUnitTests.RepositoryUnitTest
{
    [TestFixture]
    public class ForumTopicRepositoryUnitTests
    {
        private static readonly UserAccountRepository _userAccountRepository = new UserAccountRepository();
        private static readonly ForumPostRepository _postRepository = new ForumPostRepository(_userAccountRepository);
        private readonly ForumTopicRepository _topicRepository = new ForumTopicRepository(_postRepository);

        [Test]
        public void Should_get_topic_by_Id()
        {
            var forumTopic = _topicRepository.GetForumTopicById(27);
            Assert.NotNull(forumTopic);
        }

        [Test]
        public void Should_not_get_topic_by_Id_if_doesnt_exist()
        {
            var forumTopic = _topicRepository.GetForumTopicById(0);
            Assert.Null(forumTopic);
        }

        [Test]
        public void Should_create_test_topic()
        {
            var createTopicViewModel = new CreateTopicViewModel
            {
                TopicTitle = "UnitTest",
                TopicText = "UnitTest",
                UserId = 0
            };
            var forumTopic = _topicRepository.CreateNewForumTopic(createTopicViewModel);
            Assert.AreEqual("UnitTest", forumTopic.TopicTitle);
            Assert.AreEqual("UnitTest", forumTopic.TopicText);
        }

        [Test]
        public void Should_get_all_topics()
        {
            Assert.NotNull(_topicRepository.GetAllForumTopics());
        }


    }
}
