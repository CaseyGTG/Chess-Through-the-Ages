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
        public List<PhaseProgressionModel> PhaseProgressionModel { get; set; } = new List<PhaseProgressionModel>();

        public GameProgressionModel(ContentThemeEnum contentTheme)
        {
            List<PhaseProgressionModel> model = GamePhasesController.LoadCorrectPhasesForContent(contentTheme);
            foreach(PhaseProgressionModel phase in model)
            {
                PhaseProgressionModel.Add(phase);
            }
        }
    }

    public class PhaseProgressionModel
    {
        public ScenesEnum Scene { get; set; }

        public string Name { get; set; } 

        public bool IsUnlocked { get; set; } = false;

        public List<SingleGameLevelData> levelData { get; set; } = new List<SingleGameLevelData>();
    }
}
