using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.LevelPicker
{
    public class LPLevelComponent : MonoBehaviour
    {
        [SerializeField]
        public GameObject ExpandedObject;

        [SerializeField]
        public GameObject ShrinkedObject;

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
