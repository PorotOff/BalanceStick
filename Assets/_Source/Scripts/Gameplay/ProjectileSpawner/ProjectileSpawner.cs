using System.Collections;
using UnityEngine;

public class ProjectileSpawner : Spawner<Projectile>
{
    // Temp (Убрать SerializeField)
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;
    [SerializeField] private float _impulcePower;
    [SerializeField] private ProjectileConfig _projectileConfig;
    [SerializeField] private Transform _holdlingTransform;

    private CameraBounds _cameraBounds;

    private Coroutine _coroutine;

    protected override void Awake()
    {
        base.Awake();
        _cameraBounds = new CameraBounds();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnCyclic());
    }

    public void Initialize(Transform handTransform)
    {
        _holdlingTransform = handTransform;
    }

    public IEnumerator SpawnCyclic()
    {
        while (enabled)
        {
            float waitTime = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSecondsRealtime(waitTime);

            Projectile projectile = Spawn();
            projectile.transform.position = _cameraBounds.GetRandomBoundsPosition();
            projectile.Initialize(_projectileConfig, _impulcePower, _holdlingTransform.position);
        }
    }
}