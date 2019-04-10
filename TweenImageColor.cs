using UnityEngine;
using UnityEngine.UI;

namespace cpGames.core.Tweening
{
    public class TweenImageColor : Tween
    {
        #region Fields
        private Image _image;
        public Color colorFrom;
        public Color colorTo;
        #endregion

        #region Properties
        public Image Image
        {
            get
            {
                if (_image == null)
                {
                    _image = target.GetComponent<Image>();
                }
                return _image;
            }
        }
        #endregion

        #region Methods
        protected override void Transition(float val)
        {
            var c = Color.Lerp(colorFrom, colorTo, val);
            Image.color = c;
        }

        public override void Reset()
        {
            base.Reset();
            Transition(curve.Evaluate(0));
        }
        #endregion
    }
}