using Assets.Code.Content;
using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.ChoiceMenu;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.Model;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.NewGameMenu;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu
{
    public class ContentMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public ContentMenuModel model = new ContentMenuModel();

        private List<ContentThemeEnum> availableContent;

        private int _currentThemeIndex;

        private int currentThemeIndex
        {
            get
            {
                return _currentThemeIndex;
            }

            set
            {
                _currentThemeIndex = value;
                LoadChoiceMenu();
            }
        }

        public void Load()
        {
            availableContent = ContentController.getAvailableContent();
            currentThemeIndex = 0;
            LoadChoiceMenu();
        }

        public void LoadChoiceMenu()
        {
            model.CheckAssignmentOfSerializableProperties();
            model.DeactivateAllGameObjects();
            LoadThemeText();
            LoadLeftButton();
            LoadRightButton();
            ChoiceMenuComponent choiceMenuComponent = model.ChoiceMenu.GetComponent<ChoiceMenuComponent>();
            
            if(choiceMenuComponent == null)
            {
                throw new Exception("Could not retrieve choice menu component.");
            }

            choiceMenuComponent.loadGameObject(LoadChoiceMenu, LoadNewGameMenu, LoadLoadGameMenu, availableContent.ElementAt(currentThemeIndex));
            model.ChoiceMenu.SetActive(true);
        }

        public void LoadNewGameMenu()
        {
            model.CheckAssignmentOfSerializableProperties();
            model.DeactivateAllGameObjects();
            LoadThemeText();
            NewGameMenuComponent newGameComponent = model.NewGameMenu.GetComponent<NewGameMenuComponent>();
            if(newGameComponent == null)
            {
                throw new Exception("Could not retrieve new game component.");
            }
            newGameComponent.LoadMenu(LoadChoiceMenu, availableContent.ElementAt(currentThemeIndex));
            model.NewGameMenu.SetActive(true);
        }

        public void LoadLoadGameMenu()
        {
            model.CheckAssignmentOfSerializableProperties();
            model.DeactivateAllGameObjects();
            LoadThemeText();
            model.LoadGameMenu.SetActive(true);
        }

        private void LoadThemeText()
        {
            Debug.Log(currentThemeIndex);
            TextMeshProUGUI themeText = model.ThemeText.GetComponent<TextMeshProUGUI>();
            
            if(themeText == null)
            {
                throw new Exception("Could not retreive Text component from the object.");
            }

            themeText.text = ContentController.ContentThemeSubTitle.GetValueOrDefault(availableContent.ElementAt(currentThemeIndex));
            model.ThemeText.SetActive(true);
        }

        private void LoadLeftButton()
        {
            model.LeftButton.gameObject.SetActive(currentThemeIndex > 0);
            Button leftButton = model.LeftButton.GetComponent<Button>();
            if(leftButton == null)
            {
                throw new Exception("Could not retrieve button from the object.");
            }

            leftButton.onClick.RemoveAllListeners();
            leftButton.onClick.AddListener(CurrentThemeDecrement);
        }

        private void CurrentThemeIndexIncrement()
        {
            currentThemeIndex++;
        }


        private void LoadRightButton()
        {
            model.RightButton.gameObject.SetActive(currentThemeIndex < availableContent.Count() - 1);
            Button rightButton = model.RightButton.GetComponent<Button>();
            if (rightButton == null)
            {
                throw new Exception("Could not retrieve button from the object.");
            }

            rightButton.onClick.RemoveAllListeners();
            rightButton.onClick.AddListener(CurrentThemeIndexIncrement);
        }

        private void CurrentThemeDecrement()
        {
            currentThemeIndex--;
        }
    }
}
