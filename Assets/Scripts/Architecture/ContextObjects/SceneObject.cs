using UnityEngine;

namespace Architecture.Architecture.ContextObjects
{
    public abstract class SceneObject : MonoBehaviour
    {
        public virtual void ContextInitialization() { }

        public virtual void ContextInitialized() { }

        public virtual void ContextDestroyed() { }
    }
}