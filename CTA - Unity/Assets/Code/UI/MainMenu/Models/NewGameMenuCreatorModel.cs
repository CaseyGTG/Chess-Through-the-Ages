using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Models
{
    public class NewGameMenuCreatorModel
    {
        [SerializeField]
        public GameObject Title;

        [SerializeField]
        public GameObject SaveFileNameInput;

        [SerializeField]
        public GameObject SkipIntroCheckBox;

        [SerializeField]
        public GameObject StartGameButton;
    }
}
