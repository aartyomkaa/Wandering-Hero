using System.Collections.Generic;
using NPC;
using UnityEngine;

namespace GameLogic
{
    internal class Battle : InterestTile
    {
        private static Vector3 Offset = new Vector3(0, 1, 0);

        [SerializeField] private List<Enemy> _enemies;

        private Enemy _enemy;

        private void Start()
        {
            Enemy randomEnemy = _enemies[Random.Range(0, _enemies.Count)];

            _enemy = Instantiate(randomEnemy, gameObject.transform.position + Offset, randomEnemy.transform.rotation, transform);
        }

        public override void Restart()
        {
            _enemy.gameObject.SetActive(true);

            _enemy.Restart();
        }
    }
}