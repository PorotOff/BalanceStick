using System.Collections;
using UnityEngine;

public class ProjectileSpawner : Spawner<Projectile>
{
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;
    [SerializeField] private float _impulcePower;

    // Temp (Убрать SerializeField)
    [SerializeField] private Transform _handTransform;

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
        _handTransform = handTransform;
    }

    public IEnumerator SpawnCyclic()
    {
        while (enabled)
        {
            float waitTime = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSecondsRealtime(waitTime);

            Projectile projectile = Spawn();
            projectile.transform.position = _cameraBounds.GetRandomBoundsPosition();
            projectile.Initialize(_impulcePower, _handTransform.position);
        }
    }
}