using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenDeltaRectPosition : Tween
    {
        #region Fields
        private RectTransform _rectTransform;
        private Vector2 _positionFrom;
        private Vector2 _positionTo;
        public Vector2 delta;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            _rectTransform = target.GetComponent<RectTransform>();
        }

        protected override void Transition(float val)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_positionFrom, _positionTo, val);
        }

        public override void Reset()
        {
            base.Reset();
            _rectTransform = target.GetComponent<RectTransform>();
            _positionFrom = _rectTransform.anchoredPosition;
            _positionTo = _positionFrom + delta;
        }
        #endregion
    }
}