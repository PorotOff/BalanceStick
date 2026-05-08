using System;
using UnityEngine;

[RequireComponent(typeof(DamageableCollisionDetector))]
public class Projectile : MonoBehaviour, IPooledObject<Projectile>
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _lifeTimeMilliseconds;

    private DamageableCollisionDetector _damageableCollisionDetector;

    private ProjectileConfig _config;
    private PhysicalLauncher _physicalLauncher;
    private Timer _timer;

    public event Action<Projectile> Released;

    private void Update()
    {
        _timer.Work(Time.deltaTime);
    }

    public void Initialize(ProjectileConfig config, float impulcePower, Vector2 destination)
    {
        _config = config;

        _physicalLauncher = new PhysicalLauncher(_rigidbody, impulcePower);
        _physicalLauncher.Launch(destination);

        float tickPerMilliseconds = 1000;
        _timer = new Timer(tickPerMilliseconds, _lifeTimeMilliseconds);
        _timer.Start();

        _damageableCollisionDetector = GetComponent<DamageableCollisionDetector>();

        Subscribe();
    }

    public void Release()
    {
        Unsubscribe();
        
        Released?.Invoke(this);
    }

    private void Subscribe()
    {
        _timer.TimeElapsed += Release;
        _damageableCollisionDetector.Detected += Attack;
    }

    private void Unsubscribe()
    {
        _timer.TimeElapsed -= Release;
        _damageableCollisionDetector.Detected -= Attack;
    }

    private void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(_config.Damage);
    }
}