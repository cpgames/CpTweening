using System;
using JetBrains.Annotations;
using UnityEngine;

namespace cpGames.core.Tweening
{
    public abstract class Tween : MonoBehaviour
    {
        #region ModeEnum enum
        public enum ModeEnum
        {
            Once,
            Loop,
            Reverse
        }
        #endregion

        #region Fields
        private float _t;
        private float _sign = 1;
        public ModeEnum mode;
        public bool playOnStart = false;
        public AnimationCurve curve;
        public float time = 1.0f;
        public Action callOnStart = null;
        public Action callOnFinish = null;
        public Transform target;
        #endregion

        #region Properties
        public bool IsPlaying { get; private set; }
        #endregion

        #region Methods
        protected virtual void Awake() { }

        protected virtual void Start()
        {
            if (playOnStart && !IsPlaying)
            {
                Play();
            }
        }

        protected virtual void OnEnable()
        {
            if (target != null)
            {
                Reset();

                if (playOnStart)
                {
                    Play();
                }
            }
        }

        protected virtual void OnDisable()
        {
            IsPlaying = false;
        }

        [UsedImplicitly]
        private void Update()
        {
            if (IsPlaying)
            {
                if (_t <= time && _sign > 0 ||
                    _t >= 0 && _sign < 0)
                {
                    var val = curve.Evaluate(Mathf.Clamp01(_t / time));
                    Transition(val);
                    _t += Time.fixedDeltaTime * _sign;
                }
                else
                {
                    switch (mode)
                    {
                        case ModeEnum.Once:
                            Finish();
                            break;
                        case ModeEnum.Loop:
                            Reset();
                            break;
                        case ModeEnum.Reverse:
                            _sign *= -1;
                            break;
                    }
                }
            }
        }

        protected virtual void Finish()
        {
            Transition(curve.Evaluate(1f));
            Stop();
        }

        protected abstract void Transition(float val);

        public void Play()
        {
            IsPlaying = true;
            callOnStart?.Invoke();
        }

        public void Stop()
        {
            IsPlaying = false;
            callOnFinish?.Invoke();
        }

        public void ResetAndPlay()
        {
            Reset();
            IsPlaying = true;
        }

        public void Stop(bool reset)
        {
            IsPlaying = false;
            if (reset)
            {
                Reset();
            }
        }

        public virtual void Reset()
        {
            _t = 0;
            _sign = 1;
        }
        #endregion
    }
}