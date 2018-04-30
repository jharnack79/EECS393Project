using GetThiqqq.Models;
using GetThiqqq.Services;
using GetThiqqq.Constants;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;

namespace GetThiqqq.Repository
{
    public interface IUserAccountRepository
    {
        bool AddNewAccount(CreateAccountViewModel createAccountViewModel);

        UserAccount LoginAccount(LoginAccountViewModel loginAccountViewModel);

        bool IsUsernameTaken(string userName);

        bool IsEmailTaken(string emailAddress);

        UserAccount GetUserById(int id);
    }

    public class UserAccountRepository : IUserAccountRepository
    {
        public UserAccount LoginAccount(LoginAccountViewModel loginAccountViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from UserAccounts Where Username = '" + loginAccountViewModel.Username + "' AND Password='"
                + loginAccountViewModel.Password + "' ";
            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            var userID = (int)reader["ID"];
            var emailAddress = (string)reader["EmailAddress"];

            var user = new UserAccount
            {
                Id = userID,//hijlkhiguyghk
                Username = loginAccountViewModel.Username,
                Password = loginAccountViewModel.Password,
                EmailAddress = emailAddress
            };
            sqlConnection.Close();
            return user;
        }
        public bool AddNewAccount(CreateAccountViewModel createAccountViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Count(*) from UserAccounts";
            cmd.Connection = sqlConnection;

            int newId = (int)cmd.ExecuteScalar() + 1;

            cmd.CommandText = "SET IDENTITY_INSERT [GetThiqq].[dbo].[UserAccounts] ON INSERT INTO [GetThiqq].[dbo].[UserAccounts] (ID, Username, Password, EmailAddress) " +
                "Values("  + newId + ", '" + createAccountViewModel.Username + "', '" + createAccountViewModel.Password +
                "', '" + createAccountViewModel.EmailAddress + "'); " +
                "SET IDENTITY_INSERT[GetThiqq].[dbo].[UserAccounts] OFF";

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public bool IsUsernameTaken(string username)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from UserAccounts Where Username = '"
                              + username + "'";
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var usernameFound = reader.Read();

            sqlConnection.Close();
            return usernameFound;
        }

        public bool IsEmailTaken(string emailAddress)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from UserAccounts Where EmailAddress = '"
                              + emailAddress + "'";
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var emailFound = reader.Read();

            sqlConnection.Close();
            return emailFound;
        }

        public UserAccount GetUserById(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from UserAccounts where ID = " + id;
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            var userAccount = new UserAccount()
            {
                Address = "",
                EmailAddress = (string) reader["EmailAddress"],
                Id = id,
                Password = (string) reader["Password"],
                Username = (string) reader["Username"]
            };
            sqlConnection.Close();
            return userAccount;
        }
    }
}
