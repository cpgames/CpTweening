using UnityEngine.UI;

namespace cpGames.core.Tweening
{
    public class DisableUITweenAction : TweenAction
    {
        #region Fields
        public Selectable button;
        #endregion

        #region Methods
        public override void Execute()
        {
            button.interactable = false;
        }
        #endregion
    }
}