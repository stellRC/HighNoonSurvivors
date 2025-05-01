using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    // private int enemySpawnRate = 3;
    private Vector2 randomPositionOnScreen;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            randomPositionOnScreen = Camera.main.ViewportToWorldPoint(
                new Vector2(UnityEngine.Random.value, UnityEngine.Random.value)
            );
            InstantiateEnemy();
        }
    }

    public void InstantiateEnemy()
    {
        ObjectPoolManager.SpawnObject(
            enemyData.enemyPrefab,
            randomPositionOnScreen,
            Quaternion.identity,
            ObjectPoolManager.PoolType.Enemies
        );
    }
}
