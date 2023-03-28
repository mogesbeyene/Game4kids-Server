
namespace Games4Kids
{
    public class GameSettingViewModel
    {
        public int SettingsID { get; set; }
        public int GameID { get; set; }
        public int UserID { get; set; }
        public bool? Music { get; set; }
        public bool? SoundEffect { get; set; }
        public int Difficulty { get; set; }
        public int LimitTime { get; set; }

        public GameSettingViewModel()
        {

        }

        public GameSettingViewModel(GameSetting gameSetting)
        {
            SettingsID = gameSetting.SettingsId;
            GameID = gameSetting.GameId;
            UserID = gameSetting.UserId;
            Music = gameSetting.Music;
            SoundEffect = gameSetting.SoundEffect;
            Difficulty = gameSetting.Difficulty;
            LimitTime = gameSetting.LimitTime;
        }
        public GameSetting ConvertToGameSetting(GameSettingViewModel gameSettingViewModel)
        {
            return new GameSetting
            {
                SettingsId = gameSettingViewModel.SettingsID,
                GameId = gameSettingViewModel.GameID,
                UserId = gameSettingViewModel.UserID,
                Music = gameSettingViewModel.Music,
                SoundEffect = gameSettingViewModel.SoundEffect,
                Difficulty = gameSettingViewModel.Difficulty,
                LimitTime = gameSettingViewModel.LimitTime
            };
        }
    }
}
