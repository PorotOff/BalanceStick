using UnityEngine;
using UnityEngine.Events;

public class DetectEnemyTouch : MonoBehaviour
{
    public static UnityEvent OnEnemyTouched = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnEnemyTouched?.Invoke();
        }
    }
}