using Assets.Code.MainMenu;
using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu
{
    public class SaveManagementMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public MenuModel MenuModel = new MenuModel();

        public void Load(ContentThemeEnum theme, UnityAction loadNewGameMenu)
        {
            MenuModel.Theme = theme;
            LoadContent(loadNewGameMenu);
        }

        private void LoadContent(UnityAction loadNewGameMenu)
        {
            loadSubTitleText();
            loadContinueButton(); 
            loadNewGameMenuButton(loadNewGameMenu);
        }

        private void loadNewGameMenuButton(UnityAction loadNewGameMenu)
        {
            Button NewGameButton = MenuModel.NewGameButton.GetComponent<Button>();
            NewGameButton.onClick.RemoveAllListeners();
            NewGameButton.onClick.AddListener(loadNewGameMenu);
        }

        private void loadContinueButton()
        {
            //TODO
            // MenuModel.ContinueButton
        }

        private void loadSubTitleText()
        {
            TextMeshProUGUI subTitleTextComponent = MenuModel.SubTitle.GetComponent<TextMeshProUGUI>();
            if (subTitleTextComponent != null)
            {
                subTitleTextComponent.text = GamePhasesController.ContentThemeSubTitle.GetValueOrDefault(MenuModel.Theme);
            }
        }
    }
}
