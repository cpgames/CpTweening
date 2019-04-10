using UnityEditor;
using UnityEngine;

namespace cpGames.core.Tweening
{
    [CustomEditor(typeof(TweenGroup))] [CanEditMultipleObjects]
    public class ShipCameraOrbitEditor : Editor
    {
        #region Listeners
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var tweenGroup = target as TweenGroup;

            if (GUILayout.Button("Retarget to Parent"))
            {
                var tweens = tweenGroup.transform.FindAllChildren<Tween>();
                foreach (var tween in tweens)
                {
                    tween.target = tweenGroup.transform.parent;
                }
            }
        }
        #endregion
    }
}