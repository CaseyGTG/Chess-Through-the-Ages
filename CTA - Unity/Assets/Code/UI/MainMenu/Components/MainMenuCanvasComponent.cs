using Assets.Code.AdditionalContent;
using Assets.Code.MainMenu.Components;
using Assets.Code.SaveData.Enums;
using Assets.Code.UI.MainMenu.Models;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.MainMenu
{
    internal class MainMenuCanvasComponent : MonoBehaviour
    {
        [SerializeField]
        public MainMenuCanvasModel model = new MainMenuCanvasModel();

        private int _currentContentIndex;

        public int currentContentIndex {
            get
            {
                return _currentContentIndex;
            }
            set
            {
                _currentContentIndex = value;
                loadCurrentContent();
            }
        }

        private void Awake()
        {
            model.CheckAssignmentOfSerializableProperties();
            LoadContent();
        }

        private void LoadContent()
        {
            List<ContentThemeEnum> contentToLoad = AdditionalContnetManager.GetAllAvailableContent();

            foreach(ContentThemeEnum content in contentToLoad)
            {
                GameObject createdMenu = Instantiate(model.ContentMenuPreFab);
                ContentMenuComponent component = createdMenu.GetComponent<ContentMenuComponent>();
                component.Load(content);
                createdMenu.transform.SetParent(model.MainContentColumn.transform);
                model.Menus.Add(createdMenu);
            }

            currentContentIndex = 0;
        }

        private void loadCurrentContent()
        {
            Debug.Log($"Loading current content menu {currentContentIndex}");
            DeactivateAllMenus();
            model.Menus.ElementAt(currentContentIndex).SetActive(true);
            //Menus.ElementAt(currentContentIndex).GetComponent<>
            LoadContentButtons();
        }

        private void LoadContentButtons()
        {
            LoadLeftContentButton();
            LoadRightContentButton();
        }

        private void LoadRightContentButton()
        {
            model.RightScreenButton.SetActive(currentContentIndex < model.Menus.Count() - 1);
            Button rightButton = model.RightScreenButton.GetComponent<Button>();
            rightButton.onClick.RemoveAllListeners();
            rightButton.onClick.AddListener(iterateContentUp);
        }

        private void LoadLeftContentButton()
        {
            model.LeftScreenButton.SetActive(currentContentIndex > 0);
            Button leftButton = model.LeftScreenButton.GetComponent<Button>();
            leftButton.onClick.RemoveAllListeners();
            leftButton.onClick.AddListener(iterateContentDown);
        }

        private void iterateContentDown()
        {
            currentContentIndex--;
        }

        private void iterateContentUp()
        {
            currentContentIndex++;
        }

        private void DeactivateAllMenus()
        {
            foreach(GameObject gameObject in model.Menus)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
