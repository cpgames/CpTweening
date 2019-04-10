using UnityEngine;
using UnityEngine.UI;

namespace cpGames.core.Tweening
{
    public class TweenTextColor : Tween
    {
        #region Fields
        private Color _colorStart;
        private Text _text;

        public Color colorFrom;
        public Color colorTo;
        #endregion

        #region Properties
        public Color Color => _text.color;
        #endregion

        #region Methods
        protected override void Awake()
        {
            _text = target.GetComponent<Text>();
            _colorStart = _text.color;
        }

        protected override void Transition(float val)
        {
            _text.color = Color.Lerp(colorFrom, colorTo, val);
        }

        public override void Reset()
        {
            base.Reset();
            if (_text != null)
            {
                _text.color = _colorStart;
            }
        }
        #endregion
    }
}