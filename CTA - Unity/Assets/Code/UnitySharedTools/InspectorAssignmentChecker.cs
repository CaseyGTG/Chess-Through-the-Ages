using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.UnitySharedTools
{
    internal static class InspectorAssignmentChecker
    {
        public static void CheckAssignmentOfSerializableProperties(this object objectToCheck, List<string> variableNamesToIgnore = null)
        {
            List<FieldInfo> variableValuesWithSerializeFieldAttr = objectToCheck.GetType().GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
                .Where(f => f.IsDefined(typeof(SerializeField), false))
                .ToList();

            foreach(FieldInfo entry in variableValuesWithSerializeFieldAttr)
            {
                ///Used out of necessity, because variables with attribute SerializeField are not equal to null
                if(entry.GetValue(objectToCheck).ToString() == "null")
                {
                    throw new Exception($"{entry.Name} was not assigned in inspector to parent obejct of type {objectToCheck.GetType()}");
                }
            }
        }
    }
}
