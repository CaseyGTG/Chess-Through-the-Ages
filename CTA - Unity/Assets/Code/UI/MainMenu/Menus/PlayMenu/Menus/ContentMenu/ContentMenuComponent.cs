using Assets.Code.Content;
using Assets.Code.SaveData;
using Assets.Code.SaveData.Enums;
using Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.Model;
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
                LoadCurrentContent();
            }
        }

        public void Load()
        {
            availableContent = ContentController.getAvailableContent();
            currentThemeIndex = 0;
            LoadCurrentContent();
        }

        public void LoadCurrentContent()
        {
            model.CheckAssignmentOfSerializableProperties();
            LoadThemeText();
            LoadLeftButton();
            LoadRightButton();
            LoadContinueButton();
        }

        private void LoadContinueButton()
        {
            Button continueButton = model.ContinueButton.GetComponent<Button>();
            
            if (continueButton == null)
            {
                throw new Exception("Could not retrieve button component from continue button.");
            }

            continueButton.onClick.RemoveAllListeners();

            List<SaveDataModel> saveData = SaveFileManager.GetSaveDataForGameTheme(availableContent.ElementAt(currentThemeIndex));
            if(saveData.Count == 0)
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

        private void LoadThemeText()
        {
            TextMeshProUGUI themeText = model.ThemeText.GetComponent<TextMeshProUGUI>();
            
            if(themeText == null)
            {
                throw new Exception("Could not retreive Text component from the object.");
            }

            themeText.text = ContentController.ContentThemeSubTitle.GetValueOrDefault(availableContent.ElementAt(currentThemeIndex));
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
            leftButton.onClick.AddListener(CurrentThemeIndexIncrement);
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
            rightButton.onClick.AddListener(CurrentThemeDecrement);
        }

        private void CurrentThemeDecrement()
        {
            currentThemeIndex--;
        }
    }
}
