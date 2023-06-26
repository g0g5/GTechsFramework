using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GTechs.GameFramework
{

    public abstract class Manager : MonoBehaviour
    {
        static private Dictionary<Type,Manager> m_managers = new Dictionary<Type,Manager>();

        //only in Manager scope could set managers
        static private void SetManager(Type type, Manager manager) 
        {
            m_managers.Add(type, manager);
        }

        static public T GetManager<T>() where T : Manager
        {
            return (T)m_managers.GetValueOrDefault(typeof(T));
        }

        protected virtual void Awake()
        {
            if (m_managers.GetValueOrDefault(GetType()) != null) 
            {
                Destroy(gameObject);
            }
            else
            {
                SetManager(GetType(), this);
            }
            DontDestroyOnLoad(this);
        }

        protected virtual void OnDestroy()
        {
            m_managers.Remove(GetType());
        }

    }
}




