using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class GameSetting
    {
        public int SettingsId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public bool? Music { get; set; }
        public bool? SoundEffect { get; set; }
        public int Difficulty { get; set; }
        public int LimitTime { get; set; }

        public virtual User User { get; set; }
    }
}
