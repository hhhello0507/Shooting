using System;

namespace Enemy
{
    public enum EnemyType
    {
        Normal,
        Tracking,
        Idle
    }

    public static class EnemyTypeExtensions
    {
        public static IEnemyMoveStrategy GetMoveStrategy(this EnemyType type)
        {
            IEnemyMoveStrategy strategy = type switch
            {
                EnemyType.Normal => new EnemyMoveStrategyNormal(),
                EnemyType.Tracking => new EnemyMoveStrategyTracking(),
                EnemyType.Idle => new EnemyMoveStrategyIdle(),
                _ => null
            };
            return strategy;
        }
    }
}