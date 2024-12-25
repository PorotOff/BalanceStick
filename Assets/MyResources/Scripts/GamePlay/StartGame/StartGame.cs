using System;
using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    public static event Action playerTouched;
    public static UnityEvent OnGameStarted = new UnityEvent();

    private void OnMouseDown()
    {
        OnGameStarted?.Invoke();

        gameObject.SetActive(false);
    }
}