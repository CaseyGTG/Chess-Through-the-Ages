using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
using Assets.Code.UI.MainMenu;
using Assets.Code.UI.MainMenu.Models;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.MainMenu.Components
{
    public class ContentMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public ContentMenuModel model = new ContentMenuModel();

        public void Load(ContentThemeEnum contentTheme)
        {
            model.DeactivateAllGameObjects();
            model.SaveManagementMenu.SetActive(true);
            SaveManagementMenuComponent saveManagementMenuComponent = model.SaveManagementMenu.GetComponent<SaveManagementMenuComponent>();
            if (saveManagementMenuComponent != null)
            {
                saveManagementMenuComponent.Load(contentTheme, LoadNewGameMenu);
            }
        }

        public void LoadNewGameMenu()
        {
            model.SaveManagementMenu.SetActive(false);
            model.LoadGameMenu.SetActive(false);
            model.SettingsMenu.SetActive(false);
            model.NewGameMenu.SetActive(true);
        }
    }
}
