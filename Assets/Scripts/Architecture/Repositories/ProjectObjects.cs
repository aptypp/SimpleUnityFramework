using System;
using System.Collections.Generic;
using Architecture.Architecture.ContextObjects;

namespace Architecture.Architecture.Repositories
{
    public static class ProjectObjects
    {
        private static readonly Dictionary<Type, ProjectObject> _instances;

        static ProjectObjects() => _instances = new Dictionary<Type, ProjectObject>();

        public static void Register(Type type, ProjectObject projectObject) => _instances[type] = projectObject;

        public static T GetInstance<T>() where T : ProjectObject => (T)_instances[typeof(T)];
    }
}