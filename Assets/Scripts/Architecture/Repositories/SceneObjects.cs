using System;
using System.Collections.Generic;
using Architecture.Architecture.ContextObjects;

namespace Architecture.Architecture.Repositories
{
    public static class SceneObjects
    {
        private static readonly Dictionary<Type, SceneObject> _instances;

        static SceneObjects() => _instances = new Dictionary<Type, SceneObject>();

        public static void Register(SceneObject serviceObject) => _instances.Add(serviceObject.GetType(), serviceObject);

        public static void Remove(SceneObject serviceObject) => _instances.Remove(serviceObject.GetType());

        public static T GetInstance<T>() where T : SceneObject => (T)_instances[typeof(T)];
    }
}