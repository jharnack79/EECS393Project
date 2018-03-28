using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class UserProfileViewModel
    {
        public int UserAccountId { get; set; }

        public string Address { get; set; }

        public UserAccount UserAccount { get; set; }

        public UserProfileViewModel(UserAccount userAccount)
        {
            UserAccountId = userAccount.Id;
            Address = "";
            UserAccount = userAccount;
        }
    }
}
