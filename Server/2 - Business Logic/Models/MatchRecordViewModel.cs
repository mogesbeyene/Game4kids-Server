using System;


namespace Games4Kids
{

    public class GetRequestMatchRecord {
        public string GameType;
        public string UserID;

        public GetRequestMatchRecord()
        {
        }
    }

    public class MatchRecordViewModel
    {
        public int RecordID { get; set; }
        public int UserID { get; set; }
        public int GameType { get; set; }
        public DateTime RecordDate { get; set; }
        public string Points { get; set; }

        public MatchRecordViewModel()
        {

        }
        public MatchRecordViewModel(MatchRecord matchRecord)
        {
            RecordID = matchRecord.RecordId;
            UserID = matchRecord.UserId;   
            GameType = matchRecord.GameType;
            RecordDate = matchRecord.RecordDate;
            Points = matchRecord.Points;
        }
        public MatchRecord ConvertToMatchRecord(MatchRecordViewModel matchRecordViewModel)
        {
            return new MatchRecord
            {
                RecordId = matchRecordViewModel.RecordID,
                UserId = matchRecordViewModel.UserID,
                GameType = matchRecordViewModel.GameType,
                RecordDate=matchRecordViewModel.RecordDate,
                Points = matchRecordViewModel.Points
            };
        }
    }
    
}
