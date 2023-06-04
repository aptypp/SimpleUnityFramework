using Tools.AudioSystem.AudioContainers;
using UnityEngine;
using UnityEngine.Audio;

namespace Tools.AudioSystem
{
    [CreateAssetMenu(fileName = nameof(AudioBase), menuName = "AVP/Audio/" + nameof(AudioBase))]
    public class AudioBase : ScriptableObject
    {
        public AudioMixer masterMixer => _masterMixer;
        public UIAudioContainer ui => _ui;
        public ActionAudioContainer action => _action;

        [SerializeField]
        private AudioMixer _masterMixer;
        [SerializeField]
        private UIAudioContainer _ui;
        [SerializeField]
        private ActionAudioContainer _action;
    }
}