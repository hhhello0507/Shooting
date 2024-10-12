using Interface;
using Player;
using UnityEngine;

namespace Item
{
    public class PowerUpItem: MonoBehaviour, IItem, IDestroyObject
    {
        private const float Speed = 1;
        
        private void Update()
        {
            transform.position += Vector3.down * (Speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
        }

        public void Action()
        {
            var playerFire = GameObject.FindWithTag("Player")?.GetComponent<PlayerFire>();
            if (playerFire == null) return;

            playerFire.bulletCount += 2;
            Destroy();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}