using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenDeltaPosition : Tween
    {
        #region Fields
        private Vector3 _positionFrom;
        private Vector3 _positionTo;
        public Vector3 delta;
        #endregion

        #region Methods
        protected override void Awake()
        {
            Reset();
        }

        protected override void Transition(float val)
        {
            target.position = Vector3.Lerp(_positionFrom, _positionTo, val);
        }

        public override void Reset()
        {
            _positionFrom = target.position;
            _positionTo = _positionFrom + transform.rotation * delta;
            base.Reset();
        }
        #endregion
    }
}