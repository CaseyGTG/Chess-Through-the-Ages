using Assets.Code.AdditionalContent;
using Assets.Code.SaveData.Enums;
using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.MainMenu
{
    internal class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> Menus = new List<GameObject>();

        [SerializeField]
        public GameObject LeftScreenButton;

        [SerializeField]
        public GameObject RightScreenButton;

        private void Awake()
        {
            this.CheckAssignmentOfSerializableProperties();
            LoadContent();
        }

        private void LoadContent()
        {
            List<ContentThemeEnum> contentToLoad = AdditionalContnetManager.GetAllAvailableContent();
            Debug.Log(contentToLoad.Count);
            if(contentToLoad.Count > 1)
            {
                LeftScreenButton.SetActive(true);
                RightScreenButton.SetActive(true);
            }

            foreach(ContentThemeEnum content in contentToLoad)
            {

            }
        }

        private void LoadContentThemeMenu(ContentThemeEnum contentThemeEnum)
        {

        }
    }
}
