using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData.PhaseLevelData.MainGame
{
    public static class MainGamePhasesController
    {
        public static List<PhaseProgressionModel> Phases { get; set; } = new List<PhaseProgressionModel>()
        {
            {preHistoric},
            {Agriculture }
        };

        public static PhaseProgressionModel preHistoric = new PhaseProgressionModel()
        {
            IsUnlocked = true,
            levelData = PrehistoricLevels
        };

        public static PhaseProgressionModel Agriculture = new PhaseProgressionModel()
        {
            IsUnlocked = false,
            levelData = AgricultureLevels
        };

        private static List<SingleGameLevelData> PrehistoricLevels { get; set; } = new List<SingleGameLevelData>()
        {
            {
                new SingleGameLevelData()
                {
                    HighestScore = 0,
                    unlocked = true
                }
            }
        };

        private static List<SingleGameLevelData> AgricultureLevels { get; set; } = new List<SingleGameLevelData>()
        {
            {
                new SingleGameLevelData()
                {
                    HighestScore = 0,
                    unlocked = true
                }
            }
        };
    }
}