using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Services
{
    public class ForumPost
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string PostText { get; set; }

        public void EditText(string newText)
        {
            PostText = newText;
        }
    }
}
