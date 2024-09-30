using System;
using Interface;
using Item;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDestroyObject
    {
        [SerializeField] private GameObject explosionFactory;

        private void OnCollisionEnter(Collision other)
        {
            var item = other.gameObject.GetComponent<IItem>();
            if (item != null)
            {
                item.Action();
            }
            else
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Instantiate(
                original: explosionFactory,
                position: transform.position,
                rotation: Quaternion.identity
            );
            Destroy(gameObject);
        }
    }
}