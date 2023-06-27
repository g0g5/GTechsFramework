using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GTechs.GameFramework
{
    public class EventSystemEnabler : MonoBehaviour
    {
        // attach this on external EventSystem object to avoid duplicated EventSystems.
        // Start is called before the first frame update
        private void Start()
        {
            var es = FindAnyObjectByType<EventSystem>();
            if (es != null && es != GetComponent<EventSystem>()) 
            {
                Debug.Log(es.name + "already exists.");
                gameObject.SetActive(false);
            }
        }

    }

}
