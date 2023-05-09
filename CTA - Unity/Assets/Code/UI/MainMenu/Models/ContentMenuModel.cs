using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Models
{
    [Serializable]
    public class ContentMenuModel : InspectorAssignmentModel
    {
        [SerializeField]
        public GameObject SaveManagementMenu;

        [SerializeField]
        public GameObject NewGameMenu;

        [SerializeField]
        public GameObject LoadGameMenu;

        [SerializeField]
        public GameObject SettingsMenu;
    }
}
