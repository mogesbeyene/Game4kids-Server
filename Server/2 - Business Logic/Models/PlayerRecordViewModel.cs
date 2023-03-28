using System;
using System.Collections.Generic;
using System.Text;

namespace Games4Kids
{
    public class PlayerRecordViewModel
    {
        public int UserID { get; set; }
        public string TotalPoints { get; set; }
        public string CurrentRank { get; set; }


        public PlayerRecordViewModel()
        {
        }

        public PlayerRecordViewModel(PlayerRecord playerRecord)
        {
            UserID = playerRecord.UserId;
            TotalPoints = playerRecord.TotalPoints;
            CurrentRank = playerRecord.CurrentRank;
        }



        public PlayerRecord ConvertToPlayerRecord(PlayerRecordViewModel playerRecordViewModel)
        {
            return new PlayerRecord
            {
                UserId = playerRecordViewModel.UserID,
                TotalPoints = playerRecordViewModel.TotalPoints,
                CurrentRank = playerRecordViewModel.CurrentRank
            };
        }
    }
}
