using UnityEngine;

namespace cpGames.core.Tweening
{
    public class DestroyTweenAction : TweenAction
    {
        #region Fields
        public GameObject target;
        #endregion

        #region Methods
        public override void Execute()
        {
            Destroy(target);
        }
        #endregion
    }
}