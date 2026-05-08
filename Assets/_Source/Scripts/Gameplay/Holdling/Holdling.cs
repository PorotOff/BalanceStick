using System;
using UnityEngine;

public class Holdling : MonoBehaviour, IDamageable
{
    private Health _health;

    public event Action Demolished;

    private void Awake()
    {
        _health = new Health();
    }

    private void OnEnable()
    {
        _health.BecameZero += OnHealthBecameZero;
    }

    private void OnDisable()
    {
        _health.BecameZero += OnHealthBecameZero;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnHealthBecameZero()
    {
        Demolished?.Invoke();
    }
}