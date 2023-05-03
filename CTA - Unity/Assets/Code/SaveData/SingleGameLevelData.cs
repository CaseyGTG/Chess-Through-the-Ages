namespace Assets.Code.SaveData
{
    internal class SingleGameLevelData
    {
        internal bool unlocked { get; set; } = false;

        internal int HighestScore { get; set; } = 0;

        SingleLevelRankingEnum ranking { get; set; } = SingleLevelRankingEnum.None;
    }

    internal enum SingleLevelRankingEnum 
    {
        None = 0,
        oneStar = 1,
        twoStar = 2,
        threeStar = 3
    }

}
