using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using GetThiqqq.Constants;
using GetThiqqq.Models;
using GetThiqqq.Services;

namespace GetThiqqq.Repository
{
    public interface IForumPostRepository
    {
        ForumPost CreateForumPost(CreatePostViewModel createPostViewModel);

        List<ForumPost> GetForumPostByTopicId(int id);

        List<ForumPost> GetForumPostsByUserId(int id);
    }

    public class ForumPostRepository : IForumPostRepository
    {
        public ForumPost CreateForumPost(CreatePostViewModel createPostViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Count(*) from ForumPosts";
            cmd.Connection = sqlConnection;
            var newId = (int)cmd.ExecuteScalar() + 1;

            cmd.CommandText = "Insert Into ForumPosts (ID, TopicId, UserId, PostText)" +
                              "Values(" + newId + ", '" + createPostViewModel.TopicId + "', '" +
                              createPostViewModel.UserId + "', '" + createPostViewModel.PostText + "');";


            if (cmd.ExecuteNonQuery() != 1)
                return null;


            sqlConnection.Close();
            var forumPost = new ForumPost
            {
                TopicId = createPostViewModel.TopicId,
                PostText = createPostViewModel.PostText,
                UserId = createPostViewModel.UserId
            };
            return forumPost;
        }

        public List<ForumPost> GetForumPostByTopicId(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from ForumPosts Where TopicId = " + id;
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var listOfPosts = new List<ForumPost>();

            while (reader.Read())
            {
                listOfPosts.Add(new ForumPost
                {
                    Id = (int)reader["Id"],
                    TopicId = (int)reader["TopicId"],
                    UserId = (int)reader["UserId"],
                    PostText = (string)reader["PostText"]
                });
            }
            return listOfPosts;
        }

        public List<ForumPost> GetForumPostsByUserId(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from ForumPosts Where UserId = " + id;
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var listOfPosts = new List<ForumPost>();

            while (reader.Read())
            {
                listOfPosts.Add(new ForumPost
                {
                    Id = (int)reader["Id"],
                    TopicId = (int)reader["TopicId"],
                    UserId = (int)reader["UserId"],
                    PostText = (string)reader["PostText"]
                });
            }
            return listOfPosts;
        }
    }
}
