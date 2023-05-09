using Assets.Code.SaveData.Enums;
using Assets.Code.SaveData.PhaseLevelData.MainGame;
using System.Collections.Generic;

namespace Assets.Code.SaveData
{
    public static class GamePhasesController
    {
        private static Dictionary<ContentThemeEnum, List<PhaseProgressionModel>> phaseProgressionModels = new Dictionary<ContentThemeEnum, List<PhaseProgressionModel>>()
        {
            {   ContentThemeEnum.MainGame,
                MainGamePhasesController.Phases
            },
        };

        public static List<PhaseProgressionModel> LoadCorrectPhasesForContent(ContentThemeEnum contentTheme)
        {
            return phaseProgressionModels.GetValueOrDefault(contentTheme);
        }

        public static Dictionary<ContentThemeEnum, string> ContentThemeSubTitle = new Dictionary<ContentThemeEnum, string>()
        {
            {
                ContentThemeEnum.MainGame,
                "Main game"
            },
            {
                ContentThemeEnum.Arcade,
                "Arcade"
            }
        };
    }
}