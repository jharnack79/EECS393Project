using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class CreateTopicViewModel : ViewModelBase
    { 
        public string TopicTitle { get; set; }

        public string TopicText { get; set; }
    }
}
