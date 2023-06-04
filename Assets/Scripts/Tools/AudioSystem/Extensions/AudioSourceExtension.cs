using UnityEngine;

namespace Tools.AudioSystem.Extensions
{
    public static class AudioSourceExtension
    {
        public static void Fill(this AudioSource audioSource, AudioClipContainer audioClipContainer)
        {
            audioSource.clip = audioClipContainer.clip;
            audioSource.outputAudioMixerGroup = audioClipContainer.group;
        }
    }
}