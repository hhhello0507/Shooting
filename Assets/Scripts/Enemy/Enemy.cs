using System.Collections;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private GameObject bulletFactory;
        [SerializeField] private GameObject explosionFactory;
        private EnemyType _type;

        private void OnEnable()
        {
            var rand = Random.Range(0, 10);
            _type = rand switch
            {
                < 3 => EnemyType.Normal, // 30 %: 플레이어 방향
                < 5 => EnemyType.Tracking, // 20%: 추적비행
                _ => EnemyType.Idle
            };

            if (_type == EnemyType.Idle)
            {
                StartCoroutine(nameof(FireCoroutine));
            }
        }

        private void Update()
        {
            _type.GetMoveStrategy().Move(gameObject);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator FireCoroutine()
        {
            while (true)
            {
                var bulletObject = Instantiate(
                    original: bulletFactory,
                    position: transform.position,
                    rotation: Quaternion.identity
                );

                var bullet = bulletObject.GetComponent<EnemyBullet>();

                yield return new WaitForSeconds(2.0f);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            ScoreManager.Instance.Score++;

            // Create explosion
            Instantiate(
                original: explosionFactory,
                position: transform.position,
                rotation: Quaternion.identity
            );

            // Handle to destroy
            var destroy = other.gameObject.GetComponent<IDestroyObject>();
            destroy?.Destroy();
            Destroy();
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
            var enemyManagerObject = GameObject.Find("EnemyManager");
            var manager = enemyManagerObject.GetComponent<EnemyManager>();
            manager?.enemyObjectPool.Add(gameObject);
        }
    }
}