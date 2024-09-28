using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Player
{
    public class PlayerBullet : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private float speed = 5f;
        private static readonly Vector3 Dir = Vector3.up;

        private void Update()
        {
            // 2. move (P = P0 + vt)
            transform.position += Dir * (speed * Time.deltaTime);
        }

        public void Destroy()
        {
            gameObject.SetActive(false);

            var playerFire = GameObject.Find("Player")?.GetComponent<PlayerFire>();
            if (playerFire == null) return;

            playerFire.bulletObjectPool.Add(gameObject);
        }
    }
}