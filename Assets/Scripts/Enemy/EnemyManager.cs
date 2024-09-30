using System;
using System.Collections.Generic;
using Extensions;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private Timer _timer;
        [SerializeField] private GameObject enemyFactory;

        private int poolSize = 10;
        public List<GameObject> enemyObjectPool = new();
        public Transform[] spawnPoints;

        private void Start()
        {
            CreateEnemy(poolSize);

            _timer = new(0, .1f, .5f, () =>
            {
                if (enemyObjectPool.Count > 0)
                {
                    var enemy = enemyObjectPool[0];
                    enemyObjectPool.Remove(enemy);
                    enemy.transform.position = spawnPoints.Choice().position;
                    enemy.SetActive(true);
                }
            });
        }

        private void Update()
        {
            _timer.Update();
        }

        private void CreateEnemy(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var enemy = Instantiate(enemyFactory);
                enemy.SetActive(false);
                enemyObjectPool.Add(enemy);
            }
        }
    }
}