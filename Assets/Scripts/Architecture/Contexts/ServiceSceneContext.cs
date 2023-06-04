using Architecture.Architecture.ContextObjects;
using Architecture.Architecture.Repositories;
using UnityEngine;

namespace Architecture.Architecture.Contexts
{
    public class ServiceSceneContext : MonoBehaviour
    {
        private ServiceObject[] _serviceObjects;

        private void Awake()
        {
            _serviceObjects = FindObjectsOfType<ServiceObject>();

            for (int objectIndex = 0; objectIndex < _serviceObjects.Length; objectIndex++)
            {
                ServiceObjects.Register(_serviceObjects[objectIndex]);
            }

            for (int objectIndex = 0; objectIndex < _serviceObjects.Length; objectIndex++)
            {
                _serviceObjects[objectIndex].ContextAwake();
            }
        }

        private void Start()
        {
            for (int objectIndex = 0; objectIndex < _serviceObjects.Length; objectIndex++)
            {
                _serviceObjects[objectIndex].ContextStart();
            }
        }

        private void OnDestroy()
        {
            for (int objectIndex = 0; objectIndex < _serviceObjects.Length; objectIndex++)
            {
                _serviceObjects[objectIndex].ContextDestroy();
            }

            for (int objectIndex = 0; objectIndex < _serviceObjects.Length; objectIndex++)
            {
                ServiceObjects.Remove(_serviceObjects[objectIndex]);
            }
        }
    }
}