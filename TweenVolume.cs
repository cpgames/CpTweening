using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenVolume : MonoBehaviour
    {
        #region Fields
        private float _ctr;

        public AudioSource source;
        public AnimationCurve curve;
        public float time = 1.0f;
        #endregion

        #region Methods
        private void OnEnable()
        {
            Reset();
        }

        private void Update()
        {
            if (_ctr <= time)
            {
                SetVolume(_ctr / time);
                _ctr += Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void SetVolume(float val)
        {
            source.volume = curve.Evaluate(val);
        }

        public void Reset()
        {
            _ctr = 0;
            SetVolume(0);
        }
        #endregion
    }
}