using UnityEngine.UI;

namespace cpGames.core.Tweening
{
    public class SetTextTweenAction : TweenAction
    {
        #region Fields
        public Text textField;
        public string text;
        #endregion

        #region Methods
        public override void Execute()
        {
            textField.text = text;
        }
        #endregion
    }
}