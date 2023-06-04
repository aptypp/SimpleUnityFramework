using System.Collections;
using Architecture.Architecture.ContextObjects;
using Tools.AudioSystem;
using Tools.AudioSystem.Extensions;
using UnityEngine;

namespace Game.Game.Audio
{
    public class AudioSystemService : ServiceObject
    {
        [SerializeField]
        private AudioBase _base;
        [SerializeField]
        private AudioSourcePool _audioSourcePool;

        public override void ContextStart()
        {
            StartCoroutine(Init());
        }

        public void Play(AudioClipContainer clipContainer)
        {
            AudioSource audioSource = _audioSourcePool.Get();
            audioSource.Fill(clipContainer);
            audioSource.Play();
            StartCoroutine(ReleaseWhenEndPlayingRoutine(audioSource));
        }

        private IEnumerator Init()
        {
            yield return _audioSourcePool.Init();
        }

        private IEnumerator ReleaseWhenEndPlayingRoutine(AudioSource audioSource)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            _audioSourcePool.Release(audioSource);
        }
    }
}