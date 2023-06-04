using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Tools.AudioSystem
{
    [Serializable]
    public class AudioClipContainer
    {
        public AudioClip clip;
        public AudioMixerGroup group;
    }
}