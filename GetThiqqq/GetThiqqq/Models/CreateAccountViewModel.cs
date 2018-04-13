using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Models
{
    public class CreateAccountViewModel : ViewModelBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }
    }
}
