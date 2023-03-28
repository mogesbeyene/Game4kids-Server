using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class User
    {
        public User()
        {
            GameSettings = new HashSet<GameSetting>();
            MatchRecords = new HashSet<MatchRecord>();
        }

        public int UserId { get; set; }
        public int UserRole { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public string ParentPin { get; set; }

        public virtual ICollection<GameSetting> GameSettings { get; set; }
        public virtual ICollection<MatchRecord> MatchRecords { get; set; }
    }
}
