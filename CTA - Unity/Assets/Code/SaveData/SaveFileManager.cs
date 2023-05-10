using Assets.Code.SaveData.Enums;
using Newtonsoft.Json;
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

        internal static void LoadSaveFile(SaveDataModel saveData)
        {
            CurrentSaveData = saveData;
        }

        internal static void CreateNewGame()
        {

        }

        internal static List<SaveDataModel> GetSaveDataForGameTheme(ContentThemeEnum contentTheme)
        {
            List<SaveDataModel> allSaveData = GetAllSaveData();
            return allSaveData.Where(saveData => saveData.ContentTheme == contentTheme).ToList();
        }

        private static List<SaveDataModel> GetAllSaveData()
        {
            List<SaveDataModel> result = new List<SaveDataModel>();
            List<string> saveFiles = Directory.GetFiles(Application.persistentDataPath, "*.cttaSave").ToList();
            foreach (string file in saveFiles)
            {
                string streamReader = File.OpenText(file).ToString();
                SaveDataModel saveData = JsonConvert.DeserializeObject<SaveDataModel>(streamReader.ToString());
                if(saveData != null)
                {
                    result.Add(saveData);
                }
            }
            return result;
        }
    }
}
