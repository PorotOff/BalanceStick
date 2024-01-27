using System;
using UnityEngine;

public class DetectEnemyTouch : MonoBehaviour
{
    public static Action EnemyTouched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") EnemyTouched?.Invoke();
    }
}