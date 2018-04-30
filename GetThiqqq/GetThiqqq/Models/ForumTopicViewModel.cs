using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Repository;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class ForumTopicViewModel : ViewModelBase
    {
        public ForumTopic ForumTopic { get; set; }

        public UserAccount UserAccount { get; set; }

        public int TopicId { get; set; }
        
    }
}
