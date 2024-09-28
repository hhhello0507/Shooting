using System;
using Interface;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private GameObject explosionFactory;

        private void OnCollisionEnter(Collision other)
        {
            Instantiate(
                original: explosionFactory,
                position: transform.position,
                rotation: Quaternion.identity
            );

            Destroy();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}