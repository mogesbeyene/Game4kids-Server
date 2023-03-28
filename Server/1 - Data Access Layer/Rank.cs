using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class Rank
    {
        public int RankId { get; set; }
        public string RankName { get; set; }
        public string NextLevelPoints { get; set; }
    }
}
