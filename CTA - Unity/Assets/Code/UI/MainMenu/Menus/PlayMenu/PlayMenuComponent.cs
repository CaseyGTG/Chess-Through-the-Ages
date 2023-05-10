using Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Models;
using Assets.Code.UnitySharedTools;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Components
{
    public class PlayMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public PlayMenuModel model = new PlayMenuModel();

        public void Load(UnityAction loadDefaultMenu)
        {
            model.CheckAssignmentOfSerializableProperties();
            LoadBackButton(loadDefaultMenu);
            LoadContentMenu();
        }

        private void LoadContentMenu()
        {
            ContentMenuComponent contentMenu = model.ContentMenu.GetComponent<ContentMenuComponent>();

            if (contentMenu == null)
            {
                throw new Exception("Could not retreive content menu component");
            }

            contentMenu.Load();
        }

        private void LoadBackButton(UnityAction loadDefaultMenu)
        {
            Button backButton = model.BackToMainMenuButton.GetComponent<Button>();
            
            if (backButton == null)
            {
                throw new Exception("Could not retreive button component");
            }

            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(loadDefaultMenu);
        }
    }
}