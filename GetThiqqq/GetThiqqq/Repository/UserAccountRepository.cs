using GetThiqqq.Models;
using GetThiqqq.Services;
using GetThiqqq.Constants;
using System.Data.SqlClient;

namespace GetThiqqq.Repository
{
    public interface IUserAccountRepository
    {
        bool AddNewAccount(CreateAccountViewModel createAccountViewModel);

        UserAccount LoginAccount(LoginAccountViewModel loginAccountViewModel);

        bool IsUsernameTaken(string userName);

        bool IsEmailTaken(string emailAddress);
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

            reader.Read();

            var userID = (int)reader["ID"];
            var emailAddress = (string)reader["EmailAddress"];

            var user = new UserAccount
            {
                Id = userID,
                Username = loginAccountViewModel.Username,
                Password = loginAccountViewModel.Password,
                EmailAddress = emailAddress
            };

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
            sqlConnection.Close();
            return false;
        }

        public bool IsEmailTaken(string emailAddress)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            sqlConnection.Close();
            return false;
        }
    }
}
