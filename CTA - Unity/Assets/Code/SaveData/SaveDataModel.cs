using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.SaveData
{
    [Serializable]
    internal class SaveDataModel
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

        internal ContentThemeEnum ContentTheme { get; set; }

        internal bool introFinished = false;

        internal string SafeFileName { get; set; }

        internal DateTime SaveFileCreatedTime { get; set; }

        internal DateTime LastSavedTime { get; set; }

        internal GameProgressionModel GameProgression { get; set; }
    }



    internal class NewSaveDataOptionsModel 
    {
        internal ContentThemeEnum ContentTheme { get; set; }

        internal string SafeFileName { get; set; }

        internal bool SkipIntro { get; set; } = false;
    }
}
