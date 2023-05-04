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
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        public MainMenuObjects MainMenuObjects = new MainMenuObjects();
        
        
        private void Awake()
        {
            LoadNewGameButton();
        }

        private void LoadNewGameButton()
        {
            if(MainMenuObjects.NewGameButton == null)
            {
                throw new Exception("New game button was not set in the inspector");
            }

            Button button = MainMenuObjects.NewGameButton.GetComponent<Button>();
            if( button == null )
            {
                throw new Exception("New game button object does not contain a button component.");
            }

            button.onClick.AddListener(LoadNewGameScreen);
        }

        private void LoadNewGameScreen()
        {

        }
    }
}
