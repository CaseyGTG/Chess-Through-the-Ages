using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.UI.MainMenu.Models
{
    public class InspectorAssignmentModel
    {
        public void DeactivateAllGameObjects()
        {
            foreach(FieldInfo info in this.GetType().GetFields())
            {
                if(info.FieldType == typeof(GameObject))
                {
                    GameObject gameObject = (GameObject)info.GetValue(this);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}