using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenScale : Tween
    {
        #region Fields
        private Vector3 _scaleStart;
        public Vector3 scaleFrom;
        public Vector3 scaleTo;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            _scaleStart = target.localScale;
        }

        protected override void Transition(float val)
        {
            target.localScale = Vector3.Lerp(scaleFrom, scaleTo, val);
        }

        public override void Reset()
        {
            base.Reset();
            target.localScale = _scaleStart;
        }
        #endregion
    }
}