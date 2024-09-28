using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private const float Speed = 5f;

        private void Update()
        {
            // input
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");

            // handle
            var dir = new Vector3(h, v, 0).normalized;

            // output
            // transform.Translate(dir * speed * Time.deltaTime);
            // P = P0 + vt
            // v = speed
            // t = Time.deltaTime
            // dir는 방향
            transform.position += dir * (Speed * Time.deltaTime);
        }
    }
}