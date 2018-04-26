using System.Collections.Generic;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class UserAccountViewModel : ViewModelBase
    {
        public string Username { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string Address { get; set; }

        public List<ForumPost> UserPosts { get; set; }

    }
}
