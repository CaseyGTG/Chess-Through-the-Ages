using Assets.Code.UnitySharedTools.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Menus.PlayMenu.Models
{
    [Serializable]
    public class PlayMenuModel : AssignableObjectsModelBase
    {
        [SerializeField]
        public GameObject BackToMainMenuButton;

        [SerializeField]
        public GameObject ContentMenu;
    }
}
