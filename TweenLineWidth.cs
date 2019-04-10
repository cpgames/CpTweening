using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenLineWidth : Tween
    {
        #region Fields
        private LineRenderer _line;
        public float widthFrom;
        public float widthTo;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            _line = target.GetComponent<LineRenderer>();
        }

        protected override void Transition(float val)
        {
            var width = Mathf.Lerp(widthFrom, widthTo, val);
            _line.startWidth = width;
            _line.endWidth = width;
        }
        #endregion
    }
}