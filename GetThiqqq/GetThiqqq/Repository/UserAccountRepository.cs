using GetThiqqq.Models;
using GetThiqqq.Constants;
using System.Data.SqlClient;

namespace GetThiqqq.Repository
{
    public interface IUserAccountRepository
    {
        void AddNewAccount(CreateAccountViewModel createAccountViewModel);
    }

    public class UserAccountRepository : IUserAccountRepository
    {
        public void AddNewAccount(CreateAccountViewModel createAccountViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = " Select Count(*) from UserAccounts";
            cmd.Connection = sqlConnection;

            int newId = (int)cmd.ExecuteScalar() + 1;

            cmd.CommandText = "SET IDENTITY_INSERT [GetThiqq].[dbo].[UserAccounts] ON INSERT INTO [GetThiqq].[dbo].[UserAccounts] (ID, Username, Password, EmailAddress) " +
                "Values("  + newId + ", '" + createAccountViewModel.Username + "', '" + createAccountViewModel.Password +
                "', '" + createAccountViewModel.EmailAddress + "'); " +
                "SET IDENTITY_INSERT[GetThiqq].[dbo].[UserAccounts] OFF";

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
