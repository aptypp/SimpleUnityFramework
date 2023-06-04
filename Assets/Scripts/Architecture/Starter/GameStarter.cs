using System.Collections;
using Architecture.Architecture.ScenesManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Architecture.Starter
{
    public class GameStarter : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync((int)SceneName.Services, LoadSceneMode.Additive);

            yield return ScenesLoaderExtension.LoadMenu();

            yield return SceneManager.UnloadSceneAsync((int)SceneName.Start);
        }
    }
}