using Architecture.Architecture.ContextObjects;
using Architecture.Architecture.Repositories;

namespace Game.Game.Test.TestServices
{
    public class MySecondTestServiceObject : ServiceObject
    {
        private MyTestServiceObject _myTestServiceObject;

        public override void ContextAwake()
        {
            _myTestServiceObject = ServiceObjects.GetInstance<MyTestServiceObject>();
        }

        public override void ContextStart()
        {
            _myTestServiceObject.SomeDebug();
        }
    }
}