using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GTechs.GameFramework
{

    public class GameManager : Manager
    {
        //Data fields
        public string CurrentLevelName { get; protected set; }
        public string LoadingLevelName { get; protected set; }
        public float LoadingProgress { get; protected set; }
        //other managers. readonly list: it's determined on startup.
        public List<Manager> managers = new List<Manager>();

        //Events
        //called on loading level and loaded
        [HideInInspector] public UnityEvent<GameManager> loadingLevel;
        [HideInInspector] public UnityEvent<GameManager> loadedLevel;
        //called on exit to main menu
        [HideInInspector] public UnityEvent<GameManager> exitingToMainMenu;
        [HideInInspector] public UnityEvent<GameManager> exitedToMainMenu;
        //called on quit
        [HideInInspector] public UnityEvent<GameManager> quitingGame;

        protected override void Awake()
        {
            base.Awake();
            foreach (var manager in managers) 
            {
                Instantiate(manager);
            }
            CurrentLevelName = "MainMenu";
        }

        public virtual void LoadLevel(string levelName)
        {
            LoadingLevelName = levelName;
            LoadingProgress = 0.0f;
            StartCoroutine(LoadLevelAsync(levelName));
            loadingLevel.Invoke(this);
        }

        public virtual void ExitToMainMenu()
        {
            CurrentLevelName = "MainMenu";
            LoadingLevelName = "MainMenu";
            exitingToMainMenu.Invoke(this);
            SceneManager.LoadScene("MainMenu");
            exitedToMainMenu.Invoke(this);
        }


        public virtual void QuitToDesktop()
        {
            quitingGame.Invoke(this);
            //¸Ð¾õ»á³öbug
            foreach (var manager in managers)
            {
                Destroy(manager.gameObject);
            }
            Application.Quit();
        }

        private IEnumerator LoadLevelAsync(string levelName) 
        {
            var op = SceneManager.LoadSceneAsync(levelName);
            while (!op.isDone)
            {
                LoadingProgress = op.progress;
                yield return null;
            }
            // load finish!
            LoadingProgress = 100.0f;
            CurrentLevelName = levelName;
            loadedLevel.Invoke(this);
        }
    }
}