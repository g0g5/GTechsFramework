using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GTechs.GameFramework;

namespace GTechs.GameFramework
{
    public abstract class Manager : Singleton<Manager>
    {

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

    }
}




