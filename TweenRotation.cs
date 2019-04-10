using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenRotation : Tween
    {
        #region Fields
        private Quaternion _rotationStart;
        public Vector3 rotateFrom;
        public Vector3 rotateTo;
        #endregion

        #region Methods
        protected override void Awake()
        {
            _rotationStart = target.localRotation;
        }

        protected override void Transition(float val)
        {
            target.localRotation = Quaternion.Euler(Vector3.Lerp(rotateFrom, rotateTo, val));
        }

        public override void Reset()
        {
            base.Reset();
            target.localRotation = _rotationStart;
        }
        #endregion
    }
}