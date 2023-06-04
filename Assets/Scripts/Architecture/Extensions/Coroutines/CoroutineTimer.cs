using System;
using System.Collections;
using UnityEngine;

namespace Architecture.Architecture.Extensions.Coroutines
{
    public static class CoroutineTimer
    {
        public static IEnumerator TimerUnscaled(TimeSpan time) => TimerUnscaled(time, _ => { }, TimeSpan.Zero, () => { });
        public static IEnumerator TimerUnscaled(TimeSpan time, Action onEnd) => TimerUnscaled(time, _ => { }, TimeSpan.Zero, onEnd);

        public static IEnumerator TimerUnscaled(TimeSpan time, Action<TimeSpan> onUpdate, TimeSpan updateRate, Action onEnd)
        {
            WaitForSecondsRealtime updateRateDelay = new((float)updateRate.TotalSeconds);

            TimeSpan timeToEnd = time;
            TimeSpan updateTime = TimeSpan.Zero;
            TimeSpan deltaTime = TimeSpan.Zero;

            while (timeToEnd > TimeSpan.Zero)
            {
                timeToEnd = timeToEnd.Subtract(deltaTime);
                updateTime = updateTime.Add(deltaTime);

                if (updateTime >= updateRate)
                {
                    onUpdate(timeToEnd);
                    updateTime = TimeSpan.Zero;
                }

                float startAwaitTime = Time.unscaledTime;

                yield return timeToEnd > updateRate ? updateRateDelay : null;

                deltaTime = TimeSpan.FromSeconds(Time.unscaledTime - startAwaitTime);
            }

            onEnd();
        }

        public static IEnumerator TimerScaled(TimeSpan time) => TimerScaled(time, _ => { }, TimeSpan.Zero, () => { });
        public static IEnumerator TimerScaled(TimeSpan time, Action onEnd) => TimerScaled(time, _ => { }, TimeSpan.Zero, onEnd);

        public static IEnumerator TimerScaled(TimeSpan time, Action<TimeSpan> onUpdate, TimeSpan updateRate, Action onEnd)
        {
            WaitForSeconds updateRateDelay = new((float)updateRate.TotalSeconds);

            TimeSpan timeToEnd = time;
            TimeSpan updateTime = TimeSpan.Zero;
            TimeSpan deltaTime = TimeSpan.Zero;

            while (timeToEnd > TimeSpan.Zero)
            {
                timeToEnd = timeToEnd.Subtract(deltaTime);
                updateTime = updateTime.Add(deltaTime);

                if (updateTime >= updateRate)
                {
                    onUpdate(timeToEnd);
                    updateTime = TimeSpan.Zero;
                }

                float startAwaitTime = Time.time;

                yield return timeToEnd > updateRate ? updateRateDelay : null;

                deltaTime = TimeSpan.FromSeconds(Time.time - startAwaitTime);
            }

            onEnd();
        }
    }
}