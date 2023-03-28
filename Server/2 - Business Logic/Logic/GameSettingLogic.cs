using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games4Kids
{
    public class GameSettingLogic : BaseLogic
    {
        public GameSettingLogic(Games4KidsContext db) : base(db) { }

        public GameSettingViewModel AddDefualtGameSetting(GameSettingViewModel gameSetting)
        {
            GameSetting gameSettingDB = gameSetting.ConvertToGameSetting(gameSetting);
            DB.GameSettings.Add(gameSettingDB);
            DB.SaveChanges();
            return gameSetting;
        }

        public GameSettingViewModel GetGameSetting(int playerID)
        {
            return DB.GameSettings.Where(s => s.UserId == playerID).Select(s => new GameSettingViewModel(s)).Single();
        }

        public bool IsSettingExists(int settingsID)
        {
            return DB.GameSettings.Any(s => s.SettingsId == settingsID);
        }

        public GameSettingViewModel UpdateLockTime(int userID, GameSettingViewModel gameSetting)
        {
            GameSetting gameSettings = DB.GameSettings.SingleOrDefault(s => s.UserId == userID);
            if (gameSetting == null)
                return null;

            gameSettings.LimitTime = gameSetting.LimitTime;

            DB.SaveChanges();
            return new GameSettingViewModel(gameSettings);
        }


        public GameSettingViewModel UpdateSettingsProps(int userID, GameSettingViewModel gameSetting)
        {
            GameSetting gameSettings = DB.GameSettings.SingleOrDefault(s => s.UserId == userID);
            if (gameSetting == null)
                return null;

            gameSettings.Music = gameSetting.Music;
            gameSettings.SoundEffect = gameSetting.SoundEffect;

            DB.SaveChanges();
            return new GameSettingViewModel(gameSettings);
        }
    }

}
