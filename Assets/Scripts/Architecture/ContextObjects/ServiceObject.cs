using UnityEngine;

namespace Architecture.Architecture.ContextObjects
{
    public abstract class ServiceObject : MonoBehaviour
    {
        public virtual void ContextAwake() { }

        public virtual void ContextStart() { }

        public virtual void ContextDestroy() { }
    }
}