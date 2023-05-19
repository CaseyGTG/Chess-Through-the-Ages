using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.ChoiceMenu
{
    internal class ChoiceMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public ChoiceMenuModel model;

        public void loadGameObject(UnityAction LoadChoiceMenu, UnityAction loadNewGameMenu, UnityAction loadLoadGameMenu, ContentThemeEnum content)
        {
            LoadContinueButton(content);
            LoadNewGameButton(loadNewGameMenu);
            LoadLoadGameButton(loadLoadGameMenu);
        }

        private void LoadLoadGameButton(UnityAction loadLoadGameMenu)
        {

        }

        private void LoadNewGameButton(UnityAction LoadNewGameMenu)
        {
            Button newGameButton = model.NewGameButton.GetComponent<Button>();
            if (newGameButton == null)
            {
                throw new Exception("Could not retreive button component from new game button.");
            }

            newGameButton.onClick.RemoveAllListeners();
            newGameButton.onClick.AddListener(LoadNewGameMenu);
        }

        private void LoadContinueButton(ContentThemeEnum content)
        {
            Button continueButton = model.ContinueButton.GetComponent<Button>();

            if (continueButton == null)
            {
                throw new Exception("Could not retrieve button component from continue button.");
            }

            continueButton.onClick.RemoveAllListeners();

            List<SaveDataModel> saveData = SaveFileManager.GetSaveDataForGameTheme(content);
            if (saveData.Count == 0)
            {
                continueButton.interactable = false;
            }
            else
            {
                continueButton.interactable = true;
                SaveDataModel saveToLoad = saveData.OrderByDescending(x => x.LastSavedTime).First();
                continueButton.onClick.AddListener(delegate { SaveFileManager.LoadSaveFile(saveToLoad); });
            }
        }
    }
}
