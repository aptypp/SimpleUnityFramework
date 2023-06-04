using System;
using System.Collections;
using Architecture.Architecture.ContextObjects;
using Architecture.Architecture.Contexts;
using Architecture.Architecture.UI.LoadingScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Architecture.ScenesManagement
{
    public class ScenesLoader : ServiceObject
    {
        private SceneName[] _activeScenes;
        private SceneContext[] _activeSceneContexts;

        public override void ContextAwake()
        {
            _activeScenes = Array.Empty<SceneName>();
            _activeSceneContexts = Array.Empty<SceneContext>();
        }

        public Coroutine LoadScenes(SceneName[] scenesToLoad) => StartCoroutine(LoadScenesRoutine(scenesToLoad));

        private SceneContext[] GetSceneContexts() => FindObjectsOfType<SceneContext>();

        private IEnumerator LoadScenesRoutine(SceneName[] scenesToLoad)
        {
            yield return SceneManager.LoadSceneAsync((int)SceneName.Loading, LoadSceneMode.Additive);

            LoadingScreen loadingScreen = FindObjectOfType<LoadingScreen>();

            yield return loadingScreen.Show();

            for (int sceneContextIndex = 0; sceneContextIndex < _activeSceneContexts.Length; sceneContextIndex++)
            {
                _activeSceneContexts[sceneContextIndex].Destroy();
                yield return null;
            }

            for (int sceneIndex = 0; sceneIndex < _activeScenes.Length; sceneIndex++)
            {
                yield return SceneManager.UnloadSceneAsync((int)_activeScenes[sceneIndex]);
            }

            for (int sceneIndex = 0; sceneIndex < scenesToLoad.Length; sceneIndex++)
            {
                yield return SceneManager.LoadSceneAsync((int)scenesToLoad[sceneIndex], LoadSceneMode.Additive);
            }

            SceneContext[] activeSceneContexts = GetSceneContexts();
            yield return null;

            for (int sceneContextIndex = 0; sceneContextIndex < activeSceneContexts.Length; sceneContextIndex++)
            {
                activeSceneContexts[sceneContextIndex].RegisterSceneObjects();
                yield return null;
            }

            for (int sceneContextIndex = 0; sceneContextIndex < activeSceneContexts.Length; sceneContextIndex++)
            {
                activeSceneContexts[sceneContextIndex].Initialize();
                yield return null;
            }

            for (int sceneContextIndex = 0; sceneContextIndex < activeSceneContexts.Length; sceneContextIndex++)
            {
                activeSceneContexts[sceneContextIndex].Initialized();
                yield return null;
            }

            yield return loadingScreen.Hide();

            yield return SceneManager.UnloadSceneAsync((int)SceneName.Loading);

            _activeScenes = scenesToLoad;
            _activeSceneContexts = activeSceneContexts;
        }
    }
}