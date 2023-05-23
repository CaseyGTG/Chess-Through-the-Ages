using Assets.Code.SaveData.Enums;
using Assets.Code.SaveData.PhaseLevelData;
using Assets.Code.SaveData.PhaseLevelData.MainGame;
using System.Collections.Generic;

namespace Assets.Code.SaveData
{
    public static class GamePhasesController
    {
        private static Dictionary<ContentThemeEnum, List<PhaseProgressionModel>> phaseProgressionModels = new Dictionary<ContentThemeEnum, List<PhaseProgressionModel>>()
        {
            {
                ContentThemeEnum.Testing,
                TestingPhasesController.Phases
            },

            {   
                ContentThemeEnum.MainGame,
                MainGamePhasesController.Phases
            },
        };

        public static List<PhaseProgressionModel> LoadCorrectPhasesForContent(ContentThemeEnum contentTheme)
        {
            return phaseProgressionModels.GetValueOrDefault(contentTheme);
        }

    }
}