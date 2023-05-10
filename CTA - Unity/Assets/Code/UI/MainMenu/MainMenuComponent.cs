using Assets.Code.UI.MainMenu.Menus.DefaultMenu.Components;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Components;
using Assets.Code.UI.MainMenu.Menus.SettingsMenu;
using Assets.Code.UI.MainMenu.Models;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Components
{
    public class MainMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public MainMenuSubMenusModel MainMenuScreensModel = new MainMenuSubMenusModel();

        private void Awake()
        {
            MainMenuScreensModel.CheckAssignmentOfSerializableProperties();
            LoadDefaultMenu();
        }

        private void LoadDefaultMenu()
        {
            DefaultMenuComponent defaultMenuComponent = MainMenuScreensModel.DefaultMenu.GetComponent<DefaultMenuComponent>();
            if(defaultMenuComponent == null)
            {
                throw new Exception("Could not retrieve default menu component");
            }
            
            MainMenuScreensModel.DeactivateAllGameObjects();
            defaultMenuComponent.Load(LoadPlayScreen, LoadSettingsScreen, LoadDefaultMenu);
            MainMenuScreensModel.DefaultMenu.SetActive(true);
        }

        private void LoadSettingsScreen()
        {
            SettingsMenuComponent settingsMenuComponent = MainMenuScreensModel.SettingsMenu.GetComponent<SettingsMenuComponent>();
            if (settingsMenuComponent == null)
            {
                throw new Exception("Could not retrieve settings menu component.");
            }

            MainMenuScreensModel.DeactivateAllGameObjects();
            settingsMenuComponent.Load(LoadDefaultMenu);
            MainMenuScreensModel.PlayMenu.SetActive(true);
        }

        private void LoadPlayScreen()
        {
            PlayMenuComponent playMenuComponent = MainMenuScreensModel.PlayMenu.GetComponent<PlayMenuComponent>();
            if (playMenuComponent == null)
            {
                throw new Exception("Could not retrieve play menu component.");
            }

            MainMenuScreensModel.DeactivateAllGameObjects();
            playMenuComponent.Load(LoadDefaultMenu);
            MainMenuScreensModel.PlayMenu.SetActive(true);
        }
    }
}
