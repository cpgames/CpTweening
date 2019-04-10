using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenLightIntensity : Tween
    {
        #region Fields
        private Light _light;
        public float intensityFrom;
        public float intensityTo;
        #endregion

        #region Methods
        protected override void Awake()
        {
            _light = target.GetComponent<Light>();
        }

        protected override void Transition(float val)
        {
            _light.intensity = Mathf.Lerp(intensityFrom, intensityTo, val);
        }

        public override void Reset()
        {
            base.Reset();
            if (_light != null)
            {
                _light.intensity = intensityFrom;
            }
        }
        #endregion
    }
}