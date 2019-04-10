using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenCanvasAlpha : Tween
    {
        #region Fields
        private CanvasGroup _canvasGroup;
        public float alphaFrom;
        public float alphaTo;
        #endregion

        #region Properties
        public float Alpha => _canvasGroup.alpha;
        #endregion

        #region Methods
        protected override void Awake()
        {
            _canvasGroup = target.GetComponent<CanvasGroup>();
        }

        protected override void Transition(float val)
        {
            _canvasGroup.alpha = Mathf.Lerp(alphaFrom, alphaTo, val);
        }

        public override void Reset()
        {
            base.Reset();
            if (_canvasGroup != null)
            {
                _canvasGroup.alpha = alphaFrom;
            }
        }
        #endregion
    }
}