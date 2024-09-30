using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private const float DefaultMoveSpeed = 5f;
        
        // 1당 속도 10% 증가
        // 최대값: 3
        private int _moveSpeedLevel = 0;
        public int moveSpeedLevel
        {
            get => _moveSpeedLevel;
            set => _moveSpeedLevel = Mathf.Min(3, value);
        }
        private float mergedMoveSpeed => DefaultMoveSpeed * (1 + _moveSpeedLevel / 10.0f);

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
            transform.position += dir * (mergedMoveSpeed * Time.deltaTime);
        }
    }
}