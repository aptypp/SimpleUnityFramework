using Architecture.Architecture.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Game.Test.TestProjectObjects
{
    public class TestProjectObjects : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start()
        {
            _text.text = ProjectObjects.GetInstance<TestProjectObject>().GetWorks();
        }
    }
}