using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace cpGames.core.Tweening
{
    public class TweenParticlesAlpha : MonoBehaviour
    {
        #region Fields
        private List<ParticleSystem> _particles;
        private readonly List<Color> _originalColors = new List<Color>();
        private float _ctr;

        public Transform particlesRoot;
        public AnimationCurve curve;
        public float time = 1.0f;
        public bool disableAfterDone = false;
        #endregion

        #region Methods
        [UsedImplicitly]
        private void Awake()
        {
            _particles = particlesRoot.FindAllChildrenRecursively<ParticleSystem>();
            _particles.ForEach(x => _originalColors.Add(x.main.startColor.color));
        }

        [UsedImplicitly]
        private void OnEnable()
        {
            Reset();
        }

        [UsedImplicitly]
        private void Update()
        {
            if (_ctr <= time)
            {
                SetAlpha(_ctr/time);
                _ctr += Time.deltaTime;
            }
            else
            {
                if (disableAfterDone)
                {
                    particlesRoot.gameObject.SetActive(false);
                }
                _ctr = 0;
            }
        }

        private void SetAlpha(float val)
        {
            var alpha = curve.Evaluate(val);
            for (var i = 0; i < _particles.Count; i++)
            {
                var c = _originalColors[i];
                c.a = alpha;
                var main = _particles[i].main;
                main.startColor = c;
            }
        }

        public void Reset()
        {
            _ctr = 0;
            SetAlpha(0);
            if (!particlesRoot.gameObject.activeSelf)
            {
                particlesRoot.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}