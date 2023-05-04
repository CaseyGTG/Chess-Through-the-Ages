using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData
{
    [Serializable]
    public class GameProgressionModel
    {
        public List<PhaseProgressionModel> PhaseProgressionModel { get; set; }

        public GameProgressionModel(ContentThemeEnum contentTheme)
        {
            PhaseProgressionModel = GamePhasesController.LoadCorrectPhasesForContent(contentTheme);
        }
    }

    public class PhaseProgressionModel
    {
        public bool IsUnlocked { get; set; } = false;

        public List<SingleGameLevelData> levelData { get; set; } = new List<SingleGameLevelData>();
    }
}
