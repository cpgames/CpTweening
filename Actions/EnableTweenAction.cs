﻿using UnityEngine;

namespace cpGames.core.Tweening
{
    public class EnableTweenAction : TweenAction
    {
        #region Fields
        public GameObject gameObjectToDisable;
        #endregion

        #region Methods
        public override void Execute()
        {
            gameObjectToDisable.SetActive(true);
        }
        #endregion
    }
}