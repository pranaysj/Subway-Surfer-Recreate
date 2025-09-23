using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{

    [CreateAssetMenu(fileName = "EnvironmrntData", menuName = "ScriptableObjects/Environment/EnvironmrntData", order = 1)]
    public class EnvironmentScriptableObject : ScriptableObject
    {
        public List<EnvironmentData> DataList;
    }

    [System.Serializable]
    public class EnvironmentData
    {
        public EnvironmentType environmentType;
        public GameObject environmentPrefab;
    }
}