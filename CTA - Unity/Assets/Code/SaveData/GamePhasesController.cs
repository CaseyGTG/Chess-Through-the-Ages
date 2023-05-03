using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData
{
    internal static class GamePhasesController
    {
        internal static Type GetCorrectGamePhasesEnum(ContentThemeEnum theme)
        {
            switch (theme)
            {
                case ContentThemeEnum.MainGame:
                    return typeof(MainGamePhasesEnum);
                default:
                    throw new Exception("Content not included in the GetCorrectGamePhaseEnum switch.");
            }
        }
    }
}
