using System.Collections;
using Architecture.Architecture.Extensions.Coroutines;
using UnityEngine;

namespace Architecture.Architecture.UI.LoadingScene
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        public IEnumerator Show()
        {
            yield return CoroutineExtension.AnimateUnscaled(0.0f, 1.0f, 1.0f, CanvasGroupAnimationUpdate, CanvasGroupAnimationOnEnd);
        }

        public IEnumerator Hide()
        {
            yield return CoroutineExtension.AnimateUnscaled(1.0f, 0.0f, 1.0f, CanvasGroupAnimationUpdate, CanvasGroupAnimationOnEnd);
        }

        private void CanvasGroupAnimationUpdate(float progress, float from, float to)
        {
            _canvasGroup.alpha = Mathf.Lerp(from, to, progress);
        }

        private void CanvasGroupAnimationOnEnd(float to)
        {
            _canvasGroup.alpha = to;
        }
    }
}