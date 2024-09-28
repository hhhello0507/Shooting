// using UnityEngine;
//
// namespace Bullet
// {
//     public class BulletMoveStrategyPlayer : IBulletMoveStrategy
//     {
//         private const float Speed = 7.0f;
//         private static readonly GameObject Player = GameObject.Find("Player");
//
//         public void Move(GameObject bullet)
//         {
//             var dir = bullet.transform.GetDirection(Player.transform);
//             bullet.transform.position += dir * (Speed * Time.deltaTime);
//         }
//     }
// }