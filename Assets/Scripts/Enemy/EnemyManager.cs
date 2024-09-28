using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private float _currentTime;

        private const float MinTime = .1f;
        private const float MaxTime = .5f;
        private static float CreateTime => Random.Range(MinTime, MaxTime);
        [SerializeField] private GameObject enemyFactory;

        private int poolSize = 10;
        public List<GameObject> enemyObjectPool;
        public Transform[] spawnPoints;

        private void Start()
        {
            enemyObjectPool = new();
            for (var i = 0; i < poolSize; i++)
            {
                var enemy = Instantiate(enemyFactory);
                enemyObjectPool.Add(enemy);
                enemy.SetActive(false);
            }
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= CreateTime)
            {
                if (enemyObjectPool.Count > 0)
                {
                    var enemy = enemyObjectPool[0];
                    enemyObjectPool.Remove(enemy);
                    var index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                }

                _currentTime = 0;
            }
        }
    }
}