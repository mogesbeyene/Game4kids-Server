namespace Games4Kids
{
    public enum RankTypes
    {
        Begginer = 0,
        Amateur = 1,
        Advanced = 2,
        Pro = 3
    }

    public class RankViewModel
    {
        public RankTypes RankType { get; set; }
        //public string NextLevelPoints { get; set; }
        public int Begginer { get; set; }
        public int Amateur { get; set; }
        public int Advanced { get; set; }
        public int Pro { get; set; }

        public RankViewModel()
        {
            Begginer = 0;
            Amateur = 200;
            Advanced = 400;
            Pro = 800;
        }

    }
}
