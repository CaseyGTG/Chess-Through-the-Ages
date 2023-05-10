using Assets.Code.UnitySharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.UI.MainMenu.Menus.SettingsMenu
{
    internal class SettingsMenuComponent : MonoBehaviour
    {
        [SerializeField]
        public SettingsMenuModel model = new SettingsMenuModel();

        public void Load(UnityAction loadDefaultMenu)
        {
            model.CheckAssignmentOfSerializableProperties();
            LoadBackButton(loadDefaultMenu);
        }

        private void LoadBackButton(UnityAction loadDefaultMenu)
        {
            Button backButton = model.BackToMainMenuButton.GetComponent<Button>();

            if (backButton == null)
            {
                throw new Exception("Could not retreive button component");
            }

            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(loadDefaultMenu);
        }
    }
}
