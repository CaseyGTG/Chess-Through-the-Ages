using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.NewGameMenu
{
    [Serializable]
    public class NewGameMenuModel
    {
        [SerializeField]
        public GameObject NameInputField;

        [SerializeField]
        public GameObject SkipIntroToggle;

        [SerializeField]
        public GameObject StartNewGameButton;

        [SerializeField]
        public GameObject CancelButton;
    }
}
