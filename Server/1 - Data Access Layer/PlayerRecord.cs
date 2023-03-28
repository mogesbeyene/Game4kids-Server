using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class PlayerRecord
    {
        public int UserId { get; set; }
        public string TotalPoints { get; set; }
        public string CurrentRank { get; set; }

        public virtual User User { get; set; }
    }
}
