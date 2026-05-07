using UnityEngine;

public class PhysicalLauncher
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private float _impulcePower;

    public PhysicalLauncher(Rigidbody2D rigidbody, float impulcePower)
    {
        _rigidbody = rigidbody;
        _transform = _rigidbody.transform;
        _impulcePower = impulcePower;
    }

    public void Launch(Vector2 destination)
    {
        Vector2 currentPosition = (Vector2)_transform.position;
        Vector2 direction = (destination - currentPosition).normalized;
        Vector2 force = direction * _impulcePower;

        _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}