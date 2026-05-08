using System;
using UnityEngine;

public class Health
{
    public Health()
    {
        Reset();
    }

    //

    public Health(int max)
    {
        if (max < 0)
            throw new IndexOutOfRangeException(nameof(max));

        Max = max;
        Reset();
    }

    public event Action Changed;
    public event Action BecameZero;

    public int Max { get; }
    public int Current { get; private set; }

    public void Reset()
    {
        Current = Max;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new IndexOutOfRangeException(nameof(damage));

        Current = Mathf.Max(0, Current - damage);

        if (Current == 0)
        {
            BecameZero?.Invoke();
        }
    }

    public void TakeHealth(int health)
    {
        if (health < 0)
            throw new IndexOutOfRangeException(nameof(health));

        Current = Mathf.Min(Max, Current + health);
    }

    public void Zeroize()
    {
        Current = 0;
    }
}