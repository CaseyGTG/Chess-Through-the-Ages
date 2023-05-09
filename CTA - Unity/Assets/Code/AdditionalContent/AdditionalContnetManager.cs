using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.AdditionalContent
{
    internal static class AdditionalContnetManager
    {
        public static List<ContentThemeEnum> GetAllAvailableContent()
        {
            List<ContentThemeEnum> result = new List<ContentThemeEnum>();

            result.Add(ContentThemeEnum.MainGame);
            result.Add(ContentThemeEnum.Arcade);


            GetAdditionalAvailableContentFromApi(result);

            return result;
        }

        private static void GetAdditionalAvailableContentFromApi(List<ContentThemeEnum> result)
        {
            //TODO Implement
        }
    }
}
