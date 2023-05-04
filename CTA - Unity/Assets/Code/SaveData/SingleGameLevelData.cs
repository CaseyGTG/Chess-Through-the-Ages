namespace Assets.Code.SaveData
{
    public class SingleGameLevelData
    {
        public bool unlocked { get; set; } = false;

        public int HighestScore { get; set; } = 0;

        SingleLevelRankingEnum ranking { get; set; } = SingleLevelRankingEnum.None;
    }

    public enum SingleLevelRankingEnum 
    {
        None = 0,
        oneStar = 1,
        twoStar = 2,
        threeStar = 3
    }

}
