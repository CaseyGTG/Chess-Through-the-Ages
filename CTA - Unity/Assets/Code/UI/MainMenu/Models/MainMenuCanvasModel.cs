using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Models
{
    [Serializable]
    public class MainMenuCanvasModel
    {
        [SerializeField]
        public List<GameObject> Menus = new List<GameObject>();

        [SerializeField]
        public GameObject MainContentColumn;

        [SerializeField]
        public GameObject LeftScreenButton;

        [SerializeField]
        public GameObject RightScreenButton;

        [SerializeField]
        public GameObject ContentMenuPreFab;
    }
}
