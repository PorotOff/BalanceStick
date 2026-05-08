using System;
using UnityEngine;

public class CollisionDetector<T> : MonoBehaviour
{
    public event Action<T> Detected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out T component))
        {
            Detected?.Invoke(component);
        }
    }
}