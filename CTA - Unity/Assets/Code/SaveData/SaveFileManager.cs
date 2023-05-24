using Assets.Code.SaveData.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.SaveData
{
    internal static class SaveFileManager
    {
        private static SaveDataModel _currentSaveFile;

        private static SaveDataModel CurrentSaveData
        {
            get
            {
                return _currentSaveFile;
            }

            set
            {
                _currentSaveFile = value;
            }
        }

        internal static void LoadSaveFile(SaveDataModel saveData)
        {
            CurrentSaveData = saveData;
            LoadCurrentSaveFile();
        }

        internal static void WriteCurrentSaveFile()
        {
            string saveFilePath = Application.persistentDataPath + "/" + CurrentSaveData.SafeFileName + CurrentSaveData.SaveFileCreatedTime.Ticks.ToString() + ".cttaSave";
            Debug.Log(saveFilePath);
            FileStream fs = File.Create(saveFilePath);
            fs.Close();
            string jsonSave = JsonConvert.SerializeObject(CurrentSaveData);
            File.WriteAllText(saveFilePath, jsonSave);
        }

        internal static void CreateNewGameAndLoad(ContentThemeEnum contentTheme, bool skipIntro, string saveName)
        {
            SaveDataModel newSaveData = new SaveDataModel(contentTheme, skipIntro, saveName);
            CurrentSaveData = newSaveData;
            WriteCurrentSaveFile();
            LoadCurrentSaveFile();
        }

        private static void LoadCurrentSaveFile()
        {
            SceneManager.LoadSceneAsync((int)CurrentSaveData.GameProgression.PhaseProgressionModel.Where(phase => phase.IsUnlocked == true).LastOrDefault().Scene, LoadSceneMode.Single);
        }

        internal static List<SaveDataModel> GetSaveDataForGameTheme(ContentThemeEnum contentTheme)
        {
            List<SaveDataModel> allSaveData = GetAllSaveData();
            return allSaveData.Where(saveData => saveData.ContentTheme == contentTheme).ToList();
        }

        private static List<SaveDataModel> GetAllSaveData()
        {
            List<SaveDataModel> result = new List<SaveDataModel>();
            string[] fileEntries = Directory.GetFiles(Application.persistentDataPath, "*.cttaSave", SearchOption.AllDirectories);
            foreach (string file in fileEntries)
            {
                SaveDataModel saveData = JsonConvert.DeserializeObject<SaveDataModel>(File.ReadAllText(file));
                if(saveData != null)
                {
                    result.Add(saveData);
                }
            }
            return result;
        }
    }
}
