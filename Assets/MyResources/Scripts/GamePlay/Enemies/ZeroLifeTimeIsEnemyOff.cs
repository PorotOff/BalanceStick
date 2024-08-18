using UnityEngine;

public class ZeroLifeTimeIsEnemyOff : MonoBehaviour
{
    [SerializeField]
    private float maxSecondsLifetime = 5f;
    private float secondsLifetime;

    private void Start() => secondsLifetime = maxSecondsLifetime;

    private void Update()
    {
        secondsLifetime -= Time.deltaTime;

        if (secondsLifetime <= 0)
        {
            gameObject.SetActive(false);
            secondsLifetime = maxSecondsLifetime;
        }
    }
}
