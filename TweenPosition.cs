using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenPosition : Tween
    {
        #region Space enum
        public enum Space
        {
            Local,
            World
        }
        #endregion

        #region Fields
        public Space space;
        public Vector3 positionFrom;
        public Vector3 positionTo;
        #endregion

        #region Methods
        protected override void Transition(float val)
        {
            switch (space)
            {
                case Space.Local:
                    target.localPosition = Vector3.Lerp(positionFrom, positionTo, val);
                    break;
                case Space.World:
                    target.position = Vector3.Lerp(positionFrom, positionTo, val);
                    break;
            }
        }

        public override void Reset()
        {
            base.Reset();
            switch (space)
            {
                case Space.Local:
                    target.localPosition = positionFrom;
                    break;
                case Space.World:
                    target.position = positionFrom;
                    break;
            }
        }
        #endregion
    }
}