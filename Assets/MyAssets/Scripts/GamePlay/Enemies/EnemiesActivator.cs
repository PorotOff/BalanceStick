using UnityEngine;

public class EnemiesActivator : MonoBehaviour
{
    private Transform enemiesContainer;
    public static float nextSpawnSecondsTime = 0;

    [Header("for adjust occurrence frequency")]
    [SerializeField]
    private float minSpawnSecondsTime = 1f;
    [SerializeField]
    private float maxSpawnSecondsTime = 2f;

    private int leftSide;
    private int rightSide;
    private int topSide;
    private int bottomSide;

    private bool isEnemiesActivatorActive = false;

    private void Awake() => enemiesContainer = GetComponent<Transform>();
    private void Start()
    {
        leftSide = (int)CameraBoundaries.CameraSides.leftSide;
        rightSide = (int)CameraBoundaries.CameraSides.rightSide;
        topSide = (int)CameraBoundaries.CameraSides.topSide;
        bottomSide = (int)CameraBoundaries.CameraSides.bottomSide;
    }
    private void Update() => ActivateEnemy();

    private void OnEnable()
    {
        DetectTouchForStartGame.playerTouched += ActivateEnemiesActivator;
        DetectTouchForStartGame.playerTouched += ResetTimer;
        GetExtraLifeForAD.OnReceivedExtraLife += ActivateEnemiesActivator;
        GetExtraLifeForAD.OnReceivedExtraLife += ResetTimer;

        DetectEnemyTouch.EnemyTouched += DeactivateEnemiesActivator;
    }
    private void OnDisable()
    {
        DetectTouchForStartGame.playerTouched -= ActivateEnemiesActivator;
        DetectTouchForStartGame.playerTouched -= ResetTimer;
        GetExtraLifeForAD.OnReceivedExtraLife -= ActivateEnemiesActivator;
        GetExtraLifeForAD.OnReceivedExtraLife -= ResetTimer;

        DetectEnemyTouch.EnemyTouched -= DeactivateEnemiesActivator;
    }

    private void ActivateEnemiesActivator() => isEnemiesActivatorActive = true;
    private void DeactivateEnemiesActivator() => isEnemiesActivatorActive = false;
    private void ResetTimer() => nextSpawnSecondsTime = Time.time + maxSpawnSecondsTime;

    private void ActivateEnemy()
    {
        if (Time.time >= nextSpawnSecondsTime && isEnemiesActivatorActive)
        {
            GameObject newEnemy = GetEnemyFromPool();
            if (newEnemy != null)
            {
                Vector3 spawnPosition = NewEnemySpawnPosition();
                newEnemy.transform.position = spawnPosition;
                newEnemy.SetActive(true);
            }

            nextSpawnSecondsTime = Time.time + Random.Range(minSpawnSecondsTime, maxSpawnSecondsTime);
        }
    }
    private GameObject GetEnemyFromPool()
    {
        foreach (Transform enemy in enemiesContainer)
        {
            if (!enemy.gameObject.activeInHierarchy) return enemy.gameObject;
        }

        return null;
    }
    private Vector3 NewEnemySpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        float newSpawnSide = CameraBoundaries.CameraBorders[Random.Range(leftSide, bottomSide + 1)];

        // if newSpawnSide == left or right 
        //it is Ypos
        float newSpawnPositionOnSide = Random.Range(CameraBoundaries.BottomCameraBorder, CameraBoundaries.TopCameraBorder);
        spawnPosition = GetNewSpawnPosition(spawnPosition, newSpawnSide, newSpawnPositionOnSide, transform.position.z);

        if (newSpawnSide == CameraBoundaries.TopCameraBorder || newSpawnSide == CameraBoundaries.BottomCameraBorder)
        {
            //it is Xpos
            newSpawnPositionOnSide = Random.Range(CameraBoundaries.LeftCameraBorder, CameraBoundaries.RightCameraBorder);
            spawnPosition = GetNewSpawnPosition(spawnPosition, newSpawnPositionOnSide, newSpawnSide, transform.position.z);
        }

        return spawnPosition;
    }
    private Vector3 GetNewSpawnPosition(Vector3 spawnPosition, float x, float y, float z)
    {
        spawnPosition.x = x;
        spawnPosition.y = y;
        spawnPosition.z = z;

        return spawnPosition;
    }
}