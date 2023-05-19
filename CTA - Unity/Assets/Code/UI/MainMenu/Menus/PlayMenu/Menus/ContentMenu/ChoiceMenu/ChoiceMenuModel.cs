using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.ChoiceMenu
{
    [Serializable]
    public class ChoiceMenuModel
    {
        [SerializeField]
        public GameObject ContinueButton;

        [SerializeField]
        public GameObject NewGameButton;

        [SerializeField]
        public GameObject LoadGameButton;
    }
}
