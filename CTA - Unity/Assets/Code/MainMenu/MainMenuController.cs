using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.MainMenu
{
    internal class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> Menus = new List<GameObject>();

        [SerializeField]
        public GameObject LeftScreenButton;

        [SerializeField]
        public GameObject RightScreenButton;

    }
}
