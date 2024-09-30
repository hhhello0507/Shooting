using System;
using Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Item
{
    public class UltimateItem: MonoBehaviour, IItem, IDestroyObject
    {
        private const float Speed = 0.3f;

        private void Start()
        {
            transform.rotation = Random.rotation;
        }

        private void Update()
        {
            transform.position += Vector3.down * (Speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
        }
        
        public void Action()
        {
            Destroy();
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}