using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
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

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.NewGameMenu
{
    public class NewGameMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public NewGameMenuModel model;


        public void LoadMenu(UnityAction loadChoiceMenu, ContentThemeEnum content)
        {
            model.CheckAssignmentOfSerializableProperties();
            LoadStartGameButton(content);
            LoadCancelButton(loadChoiceMenu);
            model.NameInputField.GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate { 
                model.StartNewGameButton.GetComponent<Button>().interactable = !string.IsNullOrEmpty(model.NameInputField.GetComponent<TMP_InputField>().text);
            });
        }

        private void LoadCancelButton(UnityAction loadChoiceMenu)
        {
            Button cancelButton = model.CancelButton.GetComponent<Button>();
            if(cancelButton == null )
            {
                throw new Exception("Could not retrieve button component from cancel button.");
            }

            cancelButton.onClick.RemoveAllListeners();
            cancelButton.onClick.AddListener(loadChoiceMenu);
        }

        private void LoadStartGameButton(ContentThemeEnum content)
        {
            Button startGameButton = model.StartNewGameButton.GetComponent<Button>();
            if(startGameButton == null)
            {
                throw new Exception("Could not retrieve button component form start new game button.");
            }

            startGameButton.onClick.RemoveAllListeners();
            startGameButton.onClick.AddListener(delegate { StartNewGame(content); });
            startGameButton.interactable = false;
        }

        private void StartNewGame(ContentThemeEnum content)
        {
            bool skipIntro = model.SkipIntroToggle.GetComponent<Toggle>().isOn;
            string saveFileName = model.NameInputField.GetComponent<TMP_InputField>().text;
            SaveFileManager.CreateNewGameAndLoad(content, skipIntro, saveFileName);
        }
    }
}
