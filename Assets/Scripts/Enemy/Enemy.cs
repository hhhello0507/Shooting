using System;
using System.Collections;
using Extensions;
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
        private GameObject _player;

        private void OnEnable()
        {
            _player = GameObject.FindWithTag("Player");
            var rand = Random.Range(0, 10);
            _type = rand switch
            {
                < 3 => EnemyType.Normal, // 30 %: 플레이어 방향
                < 5 => EnemyType.Tracking, // 20%: 추적비행
                _ => EnemyType.Idle
            };

            switch (_type)
            {
                case EnemyType.Idle:
                    StartCoroutine(nameof(FireCoroutine));
                    break;
                case EnemyType.Normal:
                    var dir = transform.GetDirection(_player.transform);
                    var angle = Vector3.SignedAngle(Vector3.down, dir, Vector3.forward);
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                    // transform.RotateAround(transform.position, Vector3.forward, dir.y);
                    break;
                case EnemyType.Tracking:
                    break;
                default:
                    Debug.Log("Enemy.OnEnable - _type has more types");
                    break;
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