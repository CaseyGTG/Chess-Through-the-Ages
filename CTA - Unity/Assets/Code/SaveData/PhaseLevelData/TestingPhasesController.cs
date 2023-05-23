using System.Collections.Generic;

namespace Assets.Code.SaveData.PhaseLevelData
{
    public static class TestingPhasesController
    {
        public static List<PhaseProgressionModel> Phases { get; set; } = new List<PhaseProgressionModel>()
        {
            new PhaseProgressionModel()
            {
                Name = "1",
                Scene = ScenesEnum.Testing_Lobby_1,
                IsUnlocked = true,
                levelData = new List<SingleGameLevelData>()
                {
                    new SingleGameLevelData()
                    {
                        Scene = ScenesEnum.Testing_1_1,
                        Name = "Phase one level two",
                        HighestScore = 0,
                        unlocked = true
                    }
                }
            },
            new PhaseProgressionModel()
            {
                Name = "2",
                IsUnlocked = false,
                levelData = new List<SingleGameLevelData>()
                {
                    new SingleGameLevelData()
                    {
                        Scene = ScenesEnum.Testing_1_2,
                        Name = "Phase two level one",
                        HighestScore = 0,
                        unlocked = true
                    }
                }
            }
        };
    }
}