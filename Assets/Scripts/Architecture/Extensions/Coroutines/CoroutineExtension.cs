using System;
using System.Collections;
using UnityEngine;

namespace Architecture.Architecture.Extensions.Coroutines
{
    public static class CoroutineExtension
    {
        public static IEnumerator AnimateScaled<T>(T from, T to, float duration, Action<float, T, T> onUpdate, Action<T> onEnd)
        {
            float speed = 1.0f / duration;
            for (float progress = 0; progress < 1.0f; progress += speed * Time.deltaTime)
            {
                onUpdate(progress, from, to);
                yield return null;
            }

            onEnd(to);
        }

        public static IEnumerator AnimateUnscaled<T>(T from, T to, float duration, Action<float, T, T> onUpdate, Action<T> onEnd)
        {
            float speed = 1.0f / duration;
            for (float progress = 0; progress < 1.0f; progress += speed * Time.unscaledDeltaTime)
            {
                onUpdate(progress, from, to);
                yield return null;
            }

            onEnd(to);
        }

        public static IEnumerator DelayedAction(float delay, Action callback)
        {
            yield return new WaitForSecondsRealtime(delay);
            callback();
        }
    }
}