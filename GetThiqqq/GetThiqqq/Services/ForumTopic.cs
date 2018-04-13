using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Services
{
    public class ForumTopic
    {
        public int UserId { get; set; }

        public int TopicId { get; set; }

        public string TopicTitle { get; set; }

        public string TopicText { get; set; }

        public List<ForumPost> TopicPosts { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
