using Interface;
using UnityEngine;

namespace Enemy
{
    public class EnemyBullet : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private float speed = 3f;
        private Vector3 _dir;

        private void Start()
        {
            var player = GameObject.FindWithTag("Player");
            _dir = transform.GetDirection(player.transform);
        }

        private void Update()
        {
            transform.position += _dir * (speed * Time.deltaTime);
        }

        public void Destroy()
        {
            Destroy(gameObject);
            // gameObject.SetActive(false);
            //
            // var playerFire = GameObject.Find("Player")?.GetComponent<PlayerFire>();
            // if (playerFire == null) return;
            //
            // playerFire.bulletObjectPool.Add(gameObject);
        }
    }
}