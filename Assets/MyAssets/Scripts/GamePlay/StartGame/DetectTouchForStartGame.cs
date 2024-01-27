using System;
using UnityEngine;

public class DetectTouchForStartGame : MonoBehaviour
{
    public static event Action playerTouched;

    private bool eventWorked = false;

    private void Start() => eventWorked = false;

    private void OnMouseDown()
    {
        if (!GameOver.IsGameOver && !eventWorked)
        {
            playerTouched?.Invoke();
            eventWorked = true;
        }
    }
}