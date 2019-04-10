using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenLineColor : Tween
    {
        #region Fields
        private LineRenderer _line;
        public Color colorFrom;
        public Color colorTo;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            _line = target.GetComponent<LineRenderer>();
        }

        protected override void Transition(float val)
        {
            var c = Color.Lerp(colorFrom, colorTo, val);
            _line.startColor = c;
            _line.endColor = c;
        }
        #endregion
    }
}