using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class CreatePostViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public string PostText { get; set; }

        public List<Tag> PostTags { get; set; }
        
}

}
