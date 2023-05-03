using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData
{
    [Serializable]
    internal class GameProgressionModel<TPhaseEnum> where TPhaseEnum : Enum
    {
        Dictionary<TPhaseEnum, PhaseProgressionModel> HistoryPhasesProgression { get; set; } = new Dictionary<TPhaseEnum, PhaseProgressionModel>();
    }

    internal class PhaseProgressionModel
    {

    }
}
