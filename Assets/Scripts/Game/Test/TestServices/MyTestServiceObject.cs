using Architecture.Architecture.ContextObjects;
using UnityEngine;

namespace Game.Game.Test.TestServices
{
    public class MyTestServiceObject : ServiceObject
    {
        public override void ContextAwake()
        {
            Debug.LogError("Context Awake");
        }

        public override void ContextStart()
        {
            Debug.LogError("Context Start");
        }

        public override void ContextDestroy()
        {
            Debug.LogError("Context Destroy");
        }

        public void SomeDebug()
        {
            Debug.LogError("Some Debug Info");
        }
    }
}