using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Content
{
    public static class ContentController
    {
        public static List<ContentThemeEnum> getAvailableContent()
        {
            List<ContentThemeEnum> result = new List<ContentThemeEnum>
            {
                ContentThemeEnum.MainGame,
                ContentThemeEnum.Arcade
            };

            return result;
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
