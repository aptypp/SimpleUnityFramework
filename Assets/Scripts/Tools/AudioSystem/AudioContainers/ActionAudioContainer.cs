using UnityEngine;

namespace Tools.AudioSystem.AudioContainers
{
    [CreateAssetMenu(fileName = nameof(ActionAudioContainer), menuName = "AVP/Audio/Containers/" + nameof(ActionAudioContainer))]
    public class ActionAudioContainer : ScriptableObject
    {
        [SerializeField]
        private AudioClipContainer _playerTarget;
        [SerializeField]
        private AudioClipContainer _pickupCoin;
        public AudioClipContainer playerTarget => _playerTarget;
        public AudioClipContainer pickupCoin => _pickupCoin;
    }
}