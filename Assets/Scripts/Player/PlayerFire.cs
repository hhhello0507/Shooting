using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] private GameObject bulletFactory;
        [SerializeField] private Transform firePosition;
        public int poolSize = 20;
        public List<GameObject> bulletObjectPool;

        private void Start()
        {
            bulletObjectPool = new();
            for (var i = 0; i < poolSize; i++)
            {
                var bullet = Instantiate(bulletFactory);

                var bulletScript = bullet.GetComponent<PlayerBullet>();

                bulletObjectPool.Add(bullet);
                bullet.SetActive(false);
            }

            // Handle joystick activation
            var joystickObject = GameObject.Find("VirtualJoystick");

            // #if UNITY_ANDROID
            // joystickObject.SetActive(true);
            // #elif UNITY_EDITOR || UNITY_STANDALONE
            // joystickObject.SetActive(false);
            // #endif
            return;
#if UNITY_EDITOR || UNITY_STANDALONE
            joystickObject.SetActive(false);
#endif
        }

        private void Update()
        {
            // input
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletObjectPool.Count > 0)
                {
                    var bullet = bulletObjectPool[0];
                    bullet.SetActive(true);
                    bulletObjectPool.RemoveAt(0);

                    bullet.transform.position = firePosition.position;
                }
            }
        }
    }
}