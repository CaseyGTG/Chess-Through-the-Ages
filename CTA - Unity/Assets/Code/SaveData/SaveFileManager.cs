using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.SaveData
{
    internal static class SaveFileManager
    {
        private static SaveDataModel CurrentSaveData { get; set; }

        internal static void CreateNewGame()
        {

        }

        internal static List<SaveDataModel> GetSaveDataForGameTheme(ContentThemeEnum contentTheme)
        {
            List<SaveDataModel> allSaveData = GetAllSaveData();
            throw new NotImplementedException();
        }

        private static List<SaveDataModel> GetAllSaveData()
        {
            //List<string> saveFiles = Directory.GetFiles(Application.persistentDataPath, "*cttaSave").ToList();
            throw new NotImplementedException();

        }
    }
}
