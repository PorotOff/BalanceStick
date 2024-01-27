using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField]
    private int enemiesCount = 5;
    [SerializeField]
    private GameObject enemyPrefab;
    private Transform enemiesPool;

    private void Awake() => enemiesPool = GetComponent<Transform>();
    private void Start() => CreateEnemiesInPool();

    private void CreateEnemiesInPool()
    {
        for (int i = 0;  i <= enemiesCount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, enemiesPool);
            newEnemy.SetActive(false);
        }
    }
}
