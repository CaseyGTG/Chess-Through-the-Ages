using Assets.Code.SaveData.Enums;
using System;
using UnityEngine;

namespace Assets.Code.MainMenu
{
    [Serializable]
    public class MainMenuObjects
    {
        [SerializeField]
        public ContentThemeEnum Theme;

        [SerializeField]
        public GameObject ContinueButton;

        [SerializeField]
        public GameObject NewGameButton;

        [SerializeField]
        public GameObject LoadButton;

        [SerializeField]
        public GameObject SettingsButton;

        [SerializeField]
        public GameObject QuitGameButton;
    }
}