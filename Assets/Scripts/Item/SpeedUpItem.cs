using System;
using Interface;
using Player;
using UnityEngine;

namespace Item
{
    public class SpeedUpItem: MonoBehaviour, IItem, IDestroyObject
    {
        private const float Speed = 2.5f;
        
        private void Update()
        {
            transform.position += Vector3.down * (Speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
        }

        public void Action()
        {
            var playerMove = GameObject.FindWithTag("Player")?.GetComponent<PlayerMove>();
            if (playerMove == null) return;

            playerMove.moveSpeedLevel++;
            Destroy();
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}