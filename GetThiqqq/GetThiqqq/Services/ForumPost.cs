using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Services
{
    public class ForumPost
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }

        public UserAccount UserAccount
        {
            get; set;
        }

        public string PostText { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
