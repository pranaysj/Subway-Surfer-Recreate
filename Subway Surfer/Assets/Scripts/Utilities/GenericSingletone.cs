using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class GenericSingletone<T> : MonoBehaviour where T : GenericSingletone<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
