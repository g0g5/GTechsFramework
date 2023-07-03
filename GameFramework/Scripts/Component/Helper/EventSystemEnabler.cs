using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GTechs.GameFramework
{
    public class EventSystemEnabler : MonoBehaviour
    {
        // attach this on external EventSystem object to avoid duplicated EventSystems.
        // Start is called before the first frame update
        private void Start()
        {
            //var es = FindAnyObjectByType<EventSystem>();
            //if (es != null && es != GetComponent<EventSystem>()) 
            //{
            //    Debug.Log(es.name + "already exists.");
            //    gameObject.SetActive(false);
            //}

            var own_eventsystem = GetComponent<EventSystem>();
            var eventsystems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);
            foreach (var eventsystem in eventsystems) 
            {
                if (eventsystem != own_eventsystem) 
                {
                    gameObject.SetActive(false);
                    break;
                }
            }
        }

    }

}

