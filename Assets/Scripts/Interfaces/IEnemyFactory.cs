namespace ShooterBot
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyType type);
    }
}