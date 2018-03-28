using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string Address { get; set; }

        public UserAccountViewModel(UserAccount userAccount)
        {
            Id = userAccount.Id;
            Username = userAccount.Username;
            UserPassword = userAccount.Password;
            UserEmail = userAccount.EmailAddress;
               
        }

    }
}
