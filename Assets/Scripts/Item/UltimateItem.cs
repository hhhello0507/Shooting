using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface;
using UnityEngine;
using Random = UnityEngine.Random;

// 
namespace Item
{
    public class UltimateItem : MonoBehaviour, IItem, IDestroyObject
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
            var objects = FindObjectsOfType<GameObject>()
                .Where(o => o.name != "Player")
                .Select(o => o.GetComponent<IDestroyObject>())
                .Where(o => o != null);

            foreach (var o in objects)
            {
                o.Destroy();
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}