using Assets.Code.UnitySharedTools.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Menus.DefaultMenu.Models
{
    [Serializable]
    public class DefaultMenuModel : AssignableObjectsModelBase
    {
        [SerializeField]
        public GameObject PlayButton;

        [SerializeField]
        public GameObject SettingsButton;

        [SerializeField]
        public GameObject ExitButton;
    }
}
