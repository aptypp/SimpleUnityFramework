using Architecture.Architecture.Repositories;
using UnityEngine;

namespace Architecture.Architecture.ScenesManagement
{
    public static class ScenesLoaderExtension
    {
        public static Coroutine LoadMenu()
        {
            return ServiceObjects.GetInstance<ScenesLoader>().LoadScenes(new[] { SceneName.MenuEnvironment, SceneName.MenuUi });
        }
    }
}