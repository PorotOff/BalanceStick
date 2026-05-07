using UnityEngine;

public class HideRightButtons : MonoBehaviour
{
    private Animator rightButtonsAnimator;

    private void Awake()
    {
        rightButtonsAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartGame.OnGameStarted.AddListener(Hide);
    }
    private void OnDisable()
    {
        StartGame.OnGameStarted.RemoveListener(Hide);
    }

    public void Hide()
    {
        rightButtonsAnimator.SetTrigger("HideRightButtons");
    }
}