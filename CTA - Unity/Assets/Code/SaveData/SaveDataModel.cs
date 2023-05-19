using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData
{
    [Serializable]
    public class SaveDataModel
    {
        public SaveDataModel(ContentThemeEnum contentThemeArg, bool skipIntro, string saveFileName)
        {
            ContentTheme = contentThemeArg;
            introFinished = skipIntro;
            SafeFileName = saveFileName;
            SaveFileCreatedTime = DateTime.Now;
            LastSavedTime = SaveFileCreatedTime;
            GameProgression = new GameProgressionModel(ContentTheme);
        }

        public ContentThemeEnum ContentTheme { get; set; }

        public bool introFinished = false;

        public string SafeFileName { get; set; }

        public DateTime SaveFileCreatedTime { get; set; }

        public DateTime LastSavedTime { get; set; }

        public GameProgressionModel GameProgression { get; set; }
    }
}