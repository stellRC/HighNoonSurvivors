using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private EnemyData brawlEnemy;

    [SerializeField]
    private EnemyData projectileEnemy;

    private Vector2 randomPositionOnScreen;

    void Start()
    {
        PlaceEnemy(brawlEnemy);
        PlaceEnemy(projectileEnemy);
    }

    public void SpawnMoreEnemies()
    {
        PlaceEnemy(brawlEnemy);
        PlaceEnemy(projectileEnemy);
    }

    private void PlaceEnemy(EnemyData enemyData)
    {
        int enemySpawnCount = EnemySpawnCount();
        for (int i = 0; i < enemySpawnCount; i++)
        {
            RandomScreenCornerPosition();
            InstantiateEnemy(enemyData);
        }
    }

    // random position ANYWHERE on screen
    private void RandomScreenPosition()
    {
        randomPositionOnScreen = Camera.main.ViewportToWorldPoint(
            new Vector2(Random.value, Random.value)
        );
    }

    // Left bottom corner is 0,0 and right  top corner is 1,1
    private void RandomScreenCornerPosition()
    {
        randomPositionOnScreen = Camera.main.ViewportToWorldPoint(
            new Vector2(Random.Range(0, 1), Random.Range(0, 1))
        );
    }

    private int EnemySpawnCount()
    {
        return Random.Range(1, 3);
    }

    private void InstantiateEnemy(EnemyData enemyData)
    {
        ObjectPoolManager.SpawnObject(
            enemyData.enemyPrefab,
            randomPositionOnScreen,
            Quaternion.identity,
            ObjectPoolManager.PoolType.Enemies
        );
    }
}
