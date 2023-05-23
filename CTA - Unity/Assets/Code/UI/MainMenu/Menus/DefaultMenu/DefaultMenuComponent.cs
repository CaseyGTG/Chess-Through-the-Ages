using Assets.Code.UI.MainMenu.Menus.DefaultMenu.Models;
using Assets.Code.UI.MainMenu.Models;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu.Menus.DefaultMenu.Components
{
    public class DefaultMenuComponent : MonoBehaviour
    {
        [SerializeField]
        DefaultMenuModel buttonsModel = new DefaultMenuModel();

        public void Load(UnityAction loadPlayScreen ,UnityAction loadSettingsScreen, UnityAction LoadDefaultScreen)
        {
            buttonsModel.CheckAssignmentOfSerializableProperties();
            loadPlayButton(loadPlayScreen);
            loadSettingsButton(loadSettingsScreen);
            loadQuitButton();
        }

        private void loadPlayButton(UnityAction loadPlayScreen)
        {
            Button playButton = buttonsModel.PlayButton.GetComponent<Button>();
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(loadPlayScreen);
        }

        private void loadSettingsButton(UnityAction loadSettingsScreen)
        {
            Button settingsButton = buttonsModel.SettingsButton.GetComponent<Button>();
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(loadSettingsScreen);
        }

        private void loadQuitButton()
        {
            Button quitButton = buttonsModel.ExitButton.GetComponent<Button>();
            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(delegate { Application.Quit(); });
        }

    }
}
