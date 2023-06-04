using Architecture.Architecture.Repositories;
using Architecture.Architecture.ScenesManagement;
using UnityEngine;

namespace Architecture.Architecture.Extensions
{
    public static class ScenesLoaderExtension
    {
        public static Coroutine LoadMenu()
        {
            return ServiceObjects.GetInstance<ScenesLoader>().LoadScenes(new[] { SceneName.MenuEnvironment, SceneName.MenuUi });
        }
    }
}