using UnityEngine;

namespace Enemy
{
    public interface IEnemyMoveStrategy
    {
        void Move(GameObject enemy);
    }

    // 처음에만 플레이어를 바라봄
    public class EnemyMoveStrategyNormal : IEnemyMoveStrategy
    {
        private const float Speed = 5.0f;
        private static readonly Vector3 Direction = Vector3.forward; // TODO: Fix
        
        public void Move(GameObject enemy)
        {
            enemy.transform.position += Direction * (Speed * Time.deltaTime);
        }
    }


    // 플레이어를 추적
    public class EnemyMoveStrategyTracking : IEnemyMoveStrategy
    {
        private const float Speed = 6.0f;
        private static readonly GameObject Player = GameObject.FindWithTag("Player");
        
        public void Move(GameObject enemy)
        {
            var direction = enemy.transform.GetDirection(Player.transform);
            enemy.transform.position += direction * (Speed * Time.deltaTime);
        }
    }

    // 움직이지 않음
    public class EnemyMoveStrategyIdle : IEnemyMoveStrategy
    {
        public void Move(GameObject enemy)
        {
        }
    }
}