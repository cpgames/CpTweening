using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenGroup : MonoBehaviour
    {
        #region Fields
        private List<Tween> _tweens;
        private int _tweensLeft;

        public List<TweenAction> actionsOnFinish;
        public List<TweenAction> actionsOnStart;
        public Action onFinished;
        public Action onStarted;
        #endregion

        #region Methods
        [UsedImplicitly]
        private void Awake()
        {
            _tweens = transform.FindAllChildren<Tween>();
            _tweensLeft = _tweens.Count;
            _tweens.ForEach(x => x.callOnFinish += TweenFinished);
        }

        public void SetDuration(float duration)
        {
            _tweens.ForEach(x => x.time = duration);
        }

        private void TweenFinished()
        {
            _tweensLeft--;

            if (_tweensLeft == 0)
            {
                actionsOnFinish.ForEach(x => x.Execute());
                onFinished?.Invoke();
            }
        }

        public void Play()
        {
            actionsOnStart.ForEach(x => x.Execute());
            onStarted?.Invoke();

            foreach (var tween in _tweens)
            {
                tween.ResetAndPlay();
            }
        }

        public void Stop()
        {
            foreach (var tween in _tweens)
            {
                tween.Stop();
            }
        }
        #endregion
    }
}