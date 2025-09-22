using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class ServiceLocator
    {
        //Dictionary to hold the service
        //Register service
        //Get Service
        //unregister the service
        //clear the services

        private static readonly Dictionary<Type, object> service = new Dictionary<Type, object>();

        public static void RegisterService<T>(T serviceInstance)
        {
            var type = typeof(T);

            if (service.ContainsKey(type))
            {
                Debug.LogWarning($"Service of type {type} is already registered. Overwriting the existing service.");
                return;
            }

            service[type] = serviceInstance;
        }

        public static T GetService<T>()
        {
            var type = typeof(T);
            if (service.TryGetValue(type, out object serviceInstance))
            {
                return (T)serviceInstance;
            }

            throw new Exception($"Service of type {type} is not registered.");
        }



        public static void UnRegister<T>(T serviceInstance)
        {
            var type = typeof(T);

            if (!service.ContainsKey(type))
            {
                Debug.LogWarning($"Service of type {type} is not registered. Cannot unregister.");
                return;
            }

            service.Remove(type);
        }

        public static void Clear()
        {
            service.Clear();
        }
    }
}
