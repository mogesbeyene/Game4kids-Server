using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class MatchRecord
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public int GameType { get; set; }
        public DateTime RecordDate { get; set; }
        public string Points { get; set; }

        public virtual User User { get; set; }
    }
}
