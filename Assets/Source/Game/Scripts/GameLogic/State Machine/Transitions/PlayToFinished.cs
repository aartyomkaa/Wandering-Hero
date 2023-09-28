using System.Collections;
using UnityEngine;
using Player;

namespace GameLogic
{
    internal class PlayToFinished : Transition
    {
        [SerializeField] private Wanderer _wanderer;
        [SerializeField] private RoadBuilder _roadBuilder;

        private float _waitTime = 2.5f;
        private float _elapsedTime = 0;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            NeedTransit = false;

            _wanderer.Finished += OnFinish;
            _wanderer.Death += OnFinish;

            _roadBuilder.Stuck += OnFinish;
        }

        private void OnDisable()
        {
            _wanderer.Finished -= OnFinish;
            _wanderer.Death -= OnFinish;

            _roadBuilder.Stuck -= OnFinish;
        }

        private void OnFinish()
        {
            if (_wanderer.Health == 0)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _elapsedTime = 0;
                StartCoroutine(DeathAnimation());
            }
            else
            {
                NeedTransit = true;
            }
        }

        private IEnumerator DeathAnimation()
        {
            while (_elapsedTime < _waitTime)
            {
                _elapsedTime += Time.deltaTime;

                yield return Time.deltaTime;
            }

            NeedTransit = true;
        }
    }
}