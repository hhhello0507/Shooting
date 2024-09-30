using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerFire : MonoBehaviour
    {
        private const float FireAngleRange = 10f; // -10 degrees ~ 10 degress
        [SerializeField] private GameObject bulletFactory;
        [SerializeField] private Transform firePosition;
        private const int PoolSizeEachBullet = 20;
        private int poolSize = 20;

        private int _bulletCount = 1;

        public int bulletCount
        {
            get => _bulletCount;
            set
            {
                if (value <= 7)
                {
                    _bulletCount = value;
                    var totalPoolSize = PoolSizeEachBullet * value;
                    CreateBullet(totalPoolSize - poolSize);
                    poolSize = totalPoolSize;
                }
            }
        }

        public List<GameObject> bulletObjectPool = new();

        private void Start()
        {
            CreateBullet(poolSize);

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
                var angleStep = FireAngleRange / bulletCount;
                for (var i = 0; i < bulletCount; i++)
                {
                    if (bulletObjectPool.Count == 0) return;
                    
                    var bullet = bulletObjectPool[0];
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.position;
                    bulletObjectPool.RemoveAt(0);
                    
                    var currentAngle = i * angleStep;
                    var newDir = Quaternion.Euler(0, 0, currentAngle) * Vector3.up;
                    var bulletScript = bullet.GetComponent<PlayerBullet>();
                    bulletScript.dir = newDir;
                }
            }
        }

        private void CreateBullet(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var bullet = Instantiate(bulletFactory);
                bullet.SetActive(false);
                bulletObjectPool.Add(bullet);
            }
        }
    }
}