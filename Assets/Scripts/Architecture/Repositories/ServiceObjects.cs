using System;
using System.Collections.Generic;
using Architecture.Architecture.ContextObjects;

namespace Architecture.Architecture.Repositories
{
    public static class ServiceObjects
    {
        private static readonly Dictionary<Type, ServiceObject> _instances;

        static ServiceObjects() => _instances = new Dictionary<Type, ServiceObject>();

        public static void Register(ServiceObject serviceObject) => _instances.Add(serviceObject.GetType(), serviceObject);

        public static void Remove(ServiceObject serviceObject) => _instances.Remove(serviceObject.GetType());

        public static T GetInstance<T>() where T : ServiceObject => (T)_instances[typeof(T)];
    }
}