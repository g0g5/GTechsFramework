using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GTechs.GameFramework
{

    public abstract class Manager : Singleton<Manager>
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

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            //finally I put my hands on Reflection
            SetManager(GetType(), this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_managers.Remove(GetType());
        }

    }
}




