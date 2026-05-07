using System;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject<Projectile>
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _lifeTimeMilliseconds;

    private PhysicalLauncher _physicalLauncher;
    private Timer _timer;

    public event Action<Projectile> Released;

    private void Update()
    {
        _timer.Work(Time.deltaTime);
    }

    public void Initialize(float impulcePower, Vector2 destination)
    {
        _physicalLauncher = new PhysicalLauncher(_rigidbody, impulcePower);
        _physicalLauncher.Launch(destination);

        float tickPerMilliseconds = 1000;
        _timer = new Timer(tickPerMilliseconds, _lifeTimeMilliseconds);
        _timer.Start();

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
    }

    private void Unsubscribe()
    {
        _timer.TimeElapsed -= Release;
    }
}