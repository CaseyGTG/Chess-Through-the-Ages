using System.Reflection;
using UnityEngine;

namespace Assets.Code.UnitySharedTools.Bases
{
    public class AssignableObjectsModelBase
    {
        public void DeactivateAllGameObjects()
        {
            foreach (FieldInfo fieldInfo in this.GetType().GetFields())
            {
                if (fieldInfo.FieldType == typeof(GameObject))
                {
                    GameObject fieldGameObject = fieldInfo.GetValue(this) as GameObject;
                    if (fieldGameObject != null)
                    {
                        fieldGameObject.SetActive(false);
                    }
                }
            }
        }
    }
}