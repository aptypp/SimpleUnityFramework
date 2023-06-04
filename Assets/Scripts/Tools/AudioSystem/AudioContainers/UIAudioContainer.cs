using UnityEngine;

namespace Tools.AudioSystem.AudioContainers
{
    [CreateAssetMenu(fileName = nameof(UIAudioContainer), menuName = "AVP/Audio/Containers/" + nameof(UIAudioContainer))]
    public class UIAudioContainer : ScriptableObject
    {
        [SerializeField]
        private AudioClipContainer _buttonClick;
        public AudioClipContainer buttonClick => _buttonClick;
    }
}