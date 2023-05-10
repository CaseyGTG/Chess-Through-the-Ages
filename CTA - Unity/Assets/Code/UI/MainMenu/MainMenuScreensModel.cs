using Assets.Code.UnitySharedTools.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Models
{
    [Serializable]
    public class MainMenuSubMenusModel : AssignableObjectsModelBase
    {
        [SerializeField]
        public GameObject DefaultMenu;

        [SerializeField]
        public GameObject PlayMenu;

        [SerializeField]
        public GameObject SettingsMenu;


    }
}
