using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.MainMenu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        public MenuModel MenuModel = new MenuModel();

        [SerializeField]
        public GameObject NewGameMenu;

        [SerializeField]
        public GameObject SaveManagementMenu;

        private void Awake()
        {
            LoadNewGameButton();
        }

        private void LoadNewGameButton()
        {
            if(MenuModel.NewGameButton == null)
            {
                throw new Exception("New game button was not set in the inspector");
            }

            Button button = MenuModel.NewGameButton.GetComponent<Button>();
            if( button == null )
            {
                throw new Exception("New game button object does not contain a button component.");
            }

            button.onClick.AddListener(LoadNewGameScreen);
        }

        private void LoadNewGameScreen()
        {
            if(NewGameMenu == null)
            {
                throw new Exception("New game menu was not assigned in the inspector.");
            }

            if(SaveManagementMenu == null)
            {
                throw new Exception("Save menu was not assigned in the inspector.");
            }

            NewGameMenu.SetActive(true);
            SaveManagementMenu.SetActive(false);
        }
    }
}
