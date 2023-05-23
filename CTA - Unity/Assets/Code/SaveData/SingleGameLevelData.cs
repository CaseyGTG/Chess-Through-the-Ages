using System;

namespace Assets.Code.SaveData
{
    [Serializable]
    public class SingleGameLevelData
    {
        public ScenesEnum Scene { get; set; }
        public string Name { get; set; } = "Undefined";

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
