using Extensions;
using Interface;
using UnityEngine;

// TODO: Use object pool.
namespace Enemy
{
    public class EnemyBullet : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private float speed = 1.5f;
        private Vector3 _dir;

        private void Start()
        {
            var player = GameObject.FindWithTag("Player");
            _dir = transform.GetDirection(player.transform);
            transform.LookAt(player.transform);
        }

        private void Update()
        {
            transform.position += _dir * (speed * Time.deltaTime);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}