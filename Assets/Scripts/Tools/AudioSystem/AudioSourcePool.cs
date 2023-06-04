using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.AudioSystem
{
    public class AudioSourcePool : MonoBehaviour
    {
        private const byte _POOL_CAPACITY = 10;
        [SerializeField]
        private AudioSource _audioSourcePrefab;
        private List<AudioSource> _audioSources;

        private Transform _thisTransform;

        public IEnumerator Init()
        {
            _audioSources = new List<AudioSource>(_POOL_CAPACITY);
            _thisTransform = transform;
            yield return FillPool();
        }

        public AudioSource Get()
        {
            if (_audioSources.Count == 0) return CreateAudioSource();

            AudioSource freeAudioSource = _audioSources[0];
            _audioSources.Remove(freeAudioSource);
            return freeAudioSource;
        }

        public void Release(AudioSource audioSource) => _audioSources.Add(audioSource);

        private AudioSource CreateAudioSource() => Instantiate(_audioSourcePrefab, _thisTransform);

        private IEnumerator FillPool()
        {
            for (byte audioSourceIndex = 0; audioSourceIndex < _POOL_CAPACITY; audioSourceIndex++)
            {
                Release(CreateAudioSource());
                yield return null;
            }
        }
    }
}