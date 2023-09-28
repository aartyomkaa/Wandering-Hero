using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace GameLogic
{
    internal class Battle : InterestTile
    {
        [SerializeField] private List<Skeleton> _skeletons;

        private Skeleton _skeleton;

        private void Start()
        {
            Skeleton randomEnemy = _skeletons[Random.Range(0, _skeletons.Count)];

            _skeleton = Instantiate(randomEnemy, gameObject.transform.position + Constants.StaticVariables.Offset, randomEnemy.transform.rotation, transform);
        }

        public override void Restart()
        {
            _skeleton.gameObject.SetActive(true);

            _skeleton.Restart();
        }
    }
}