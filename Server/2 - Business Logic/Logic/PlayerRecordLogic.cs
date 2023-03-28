using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games4Kids
{
    public class PlayerRecordLogic : BaseLogic
    {
        public PlayerRecordLogic(Games4KidsContext db) : base(db) { }

        public PlayerRecordViewModel AddPlayerRecord(PlayerRecordViewModel playerRecord)
        {
            bool IsPlayerRecordExist = IsPlayerRecordExists(playerRecord.UserID);
            if (IsPlayerRecordExist)
            {
                PlayerRecord playerRecordDB = DB.PlayerRecords.Where(pr => pr.UserId == playerRecord.UserID).Select(s=> s).SingleOrDefault();
                playerRecordDB.TotalPoints = playerRecord.TotalPoints;
                DB.SaveChanges();
            }
            else
            {
               // playerRecord.UserID = int.MinValue;
                PlayerRecord playerRecordDB = playerRecord.ConvertToPlayerRecord(playerRecord);

                DB.PlayerRecords.Add(playerRecordDB);
                DB.SaveChanges();
            }

            return playerRecord;
        }

        public PlayerRecordViewModel GetPlayerRecord(int id)
        {
            return DB.PlayerRecords.Where(p => p.UserId == id).Select(p => new PlayerRecordViewModel(p)).Single();
        }

        public bool IsPlayerRecordExists(int playerID)
        {
            return DB.PlayerRecords.Any(p => p.UserId == playerID);
        }

    }
}
