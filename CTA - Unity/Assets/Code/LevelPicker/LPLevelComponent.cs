using Assets.Code.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.LevelPicker
{
    public class LPLevelComponent : MonoBehaviour
    {
        [SerializeField]
        public GameObject ExpandedObject;

        [SerializeField]
        public GameObject ShrinkedObject;

        [SerializeField]
        public ScenesEnum SceneToLoad;

        public void LoadLevel()
        {
            SceneManager.LoadSceneAsync((int)SceneToLoad);
        }

        public void Expand()
        {
            ExpandedObject.SetActive(true);
            ShrinkedObject.SetActive(false);
        }

        public void Shrink()
        {
            ExpandedObject.SetActive(false);
            ShrinkedObject.SetActive(true);
        }
    }
}
