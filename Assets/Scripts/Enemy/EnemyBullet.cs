using System.Collections;
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
            if (player == null) return;
            
            _dir = transform.GetDirection(player.transform);
            transform.LookAt(player.transform);

            StartCoroutine(nameof(HandleDestroy));
        }

        private void Update()
        {
            transform.position += _dir * (speed * Time.deltaTime);
        }

        private IEnumerator HandleDestroy()
        {
            yield return new WaitForSeconds(20f);
            Debug.Log("뒤져");
            Destroy();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}