using System.Collections.Generic;
using Architecture.Architecture.ContextObjects;
using Architecture.Architecture.Repositories;
using UnityEngine;

namespace Architecture.Architecture.Contexts
{
    public class SceneContext : MonoBehaviour
    {
        private SceneObject[] _sceneObjects;

        public void RegisterSceneObjects()
        {
            GameObject[] rootObjects = gameObject.scene.GetRootGameObjects();

            List<SceneObject> sceneObjects = new();

            for (int objectIndex = 0; objectIndex < rootObjects.Length; objectIndex++)
            {
                sceneObjects.AddRange(rootObjects[objectIndex].GetComponentsInChildren<SceneObject>(true));
            }

            _sceneObjects = sceneObjects.ToArray();

            for (int objectIndex = 0; objectIndex < _sceneObjects.Length; objectIndex++)
            {
                SceneObjects.Register(_sceneObjects[objectIndex]);
            }
        }

        public void Initialize()
        {
            for (int objectIndex = 0; objectIndex < _sceneObjects.Length; objectIndex++)
            {
                _sceneObjects[objectIndex].ContextInitialization();
            }
        }

        public void Initialized()
        {
            for (int objectIndex = 0; objectIndex < _sceneObjects.Length; objectIndex++)
            {
                _sceneObjects[objectIndex].ContextInitialized();
            }
        }

        public void Destroy()
        {
            for (int objectIndex = 0; objectIndex < _sceneObjects.Length; objectIndex++)
            {
                _sceneObjects[objectIndex].ContextDestroyed();
            }

            for (int objectIndex = 0; objectIndex < _sceneObjects.Length; objectIndex++)
            {
                SceneObjects.Remove(_sceneObjects[objectIndex]);
            }
        }
    }
}