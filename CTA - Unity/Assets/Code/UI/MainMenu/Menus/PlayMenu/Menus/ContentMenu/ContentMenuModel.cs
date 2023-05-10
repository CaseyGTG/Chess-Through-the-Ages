using Assets.Code.SaveData.Enums;
using Assets.Code.UnitySharedTools.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Menus.ContentMenu.Model
{
    [Serializable]
    public class ContentMenuModel : AssignableObjectsModelBase
    {
        [SerializeField]
        public GameObject LeftButton;

        [SerializeField]
        public GameObject RightButton;

        [SerializeField]
        public GameObject ThemeText;

        [SerializeField]
        public GameObject ContinueButton;

        [SerializeField]
        public GameObject NewGameButton;

        [SerializeField]
        public GameObject LoadGameButton;


    }
}
