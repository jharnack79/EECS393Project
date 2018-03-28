using GetThiqqq.Models;
using GetThiqqq.Constants;
using System.Data.SqlClient;
using System.Data;

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
            cmd.CommandText = " Select Count(*) from UserAccount";
            cmd.Connection = sqlConnection;

            int newId = (int)cmd.ExecuteScalar() + 1;

            cmd.CommandText = "INSERT INTO UserAccount (Id, Username, Password, EmailAddress) " +
                "Values("  + newId + ", '" + createAccountViewModel.Username + "', '" + createAccountViewModel.Password +
                "', '" + createAccountViewModel.EmailAddress + "'";

        }
    }
}
