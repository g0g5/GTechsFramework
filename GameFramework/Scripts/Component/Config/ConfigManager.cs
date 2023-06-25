using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.GameFramework
{
    public class ConfigManager : Manager
    {
        protected override void Awake()
        {
            base.Awake();

            var gm = (GameManager)GameManager.Instance;
            gm.loadedLevel.AddListener((g) => { Debug.Log("I currently do nothing but sleep."); });
        }
    }
}