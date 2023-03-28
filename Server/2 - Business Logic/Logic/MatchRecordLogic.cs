using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games4Kids
{
    public class MatchRecordLogic : BaseLogic
    {
        private readonly PlayerRecordLogic playerRecordLogic;

        public MatchRecordLogic(Games4KidsContext db, PlayerRecordLogic logic) : base(db)
        {
            playerRecordLogic = logic;
        }

        public MatchRecordViewModel AddMatchRecord(MatchRecordViewModel matchRecord)
        {
            MatchRecord matchRecordDB = matchRecord.ConvertToMatchRecord(matchRecord);
            DB.MatchRecords.Add(matchRecordDB);
            DB.SaveChanges();

            PlayerRecordViewModel playerRecordViewModel = new PlayerRecordViewModel();

            playerRecordViewModel.UserID = matchRecord.UserID;

            GameType gameType = matchRecord.GameType == 1 ? GameType.FourInARow : GameType.TicTac;
            playerRecordViewModel.TotalPoints = GetSumPointsByGameType(gameType, matchRecord.UserID);
            playerRecordViewModel.CurrentRank = CalcCurrentRank(Convert.ToInt32(playerRecordViewModel.TotalPoints));

            playerRecordLogic.AddPlayerRecord(playerRecordViewModel);
            return matchRecord;
        }

        public List<MatchRecordViewModel> GetAllMatchRecord(int id)
        {
            return DB.MatchRecords.Where(m => m.UserId == id).Select(m => new MatchRecordViewModel(m)).ToList();
        }

        public bool IsMatchRecordExists(int matchRecordID)
        {
            return DB.MatchRecords.Any(s => s.RecordId == matchRecordID);
        }


        public string GetSumPointsByGameType(GameType gameType, int userID)
        {
            int indexer = Convert.ToInt32(gameType);
            List<string> points =  DB.MatchRecords.Where(matchRecord => matchRecord.GameType == indexer && matchRecord.UserId == userID).Select(s=>s.Points).ToList();
            int sum = 0;
            points.ForEach(p => sum += Convert.ToInt32(p));
            return sum.ToString();
        }


        public string CalcCurrentRank(int totalPoints)
        {
            string newRank = "0";
            RankViewModel ranks = new RankViewModel();
            if (totalPoints > ranks.Amateur && totalPoints < ranks.Advanced && totalPoints < ranks.Pro)
            {
                newRank = "1";
            }
            else if (totalPoints > ranks.Advanced && totalPoints < ranks.Pro)
            {
                newRank = "2";
            }
            else if (totalPoints > ranks.Pro)
            {
                newRank = "3";
            }
            return newRank;
        }
    }
}
