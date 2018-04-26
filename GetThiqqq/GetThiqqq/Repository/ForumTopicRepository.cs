using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using GetThiqqq.Constants;
using GetThiqqq.Models;
using GetThiqqq.Services;

namespace GetThiqqq.Repository
{
    public interface IForumTopicRepository
    {
        List<ForumTopic> GetAllForumTopics();

        ForumTopic GetForumTopicById(int id);

        ForumTopic CreateNewForumTopic(CreateTopicViewModel createTopicViewModel);
    }
    public class ForumTopicRepository : IForumTopicRepository
    {
        private readonly IForumPostRepository _forumPostRepository;

        public ForumTopicRepository(IForumPostRepository forumPostRepository)
        {
            _forumPostRepository = forumPostRepository;
        }

        public List<ForumTopic> GetAllForumTopics()
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from ForumTopic";
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var listOfTopics = new List<ForumTopic>();
            while (reader.Read())
            {
                listOfTopics.Add(new ForumTopic
                {
                    TopicId = (int)reader["ID"],
                    UserId = (int)reader["UserId"],
                    TopicText = (string)reader["TopicText"],
                    TopicTitle = (string)reader["TopicTitle"],
                    TopicPosts = _forumPostRepository.GetForumPostByTopicId((int)reader["ID"])
                });
            }

            return listOfTopics;

        }

        public ForumTopic CreateNewForumTopic(CreateTopicViewModel createTopicViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Count(*) from ForumTopic";
            cmd.Connection = sqlConnection;

            var newId = (int) cmd.ExecuteScalar() + 1;

            cmd.CommandText =
                "SET IDENTITY_INSERT [GetThiqq].[dbo].[ForumTopic] ON INSERT INTO [GetThiqq].[dbo].[ForumTopic] (ID, TopicTitle, TopicText, UserId) " +
                "Values(" + newId + ", '" + createTopicViewModel.TopicTitle + "', '" + createTopicViewModel.TopicText +
                "', '" + createTopicViewModel.UserId + "'); " +
                "SET IDENTITY_INSERT[GetThiqq].[dbo].[ForumTopic] OFF";

            if (cmd.ExecuteNonQuery() != 1)
                return null;

            var forumTopic = new ForumTopic
            {
                TopicId = newId,
                UserId = createTopicViewModel.UserId,
                TopicTitle = createTopicViewModel.TopicTitle,
                TopicText = createTopicViewModel.TopicText,
                Tags = null,
                TopicPosts = new List<ForumPost>()
            };
        
            sqlConnection.Close();
            return forumTopic;
        }

        public ForumTopic GetForumTopicById(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from ForumTopic Where Id = " + id;
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            var forumTopic = new ForumTopic
            {
                TopicId = id,
                TopicTitle = (string)reader["TopicTitle"],
                TopicText = (string)reader["TopicText"],
                TopicPosts = _forumPostRepository.GetForumPostByTopicId(id),
                Tags = null,
            };

            sqlConnection.Close();
            return forumTopic;
        }
    }
}
