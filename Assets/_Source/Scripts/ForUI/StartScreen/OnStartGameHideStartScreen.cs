using UnityEngine;

public class OnStartGameHideStartScreen : MonoBehaviour
{
    private Animator startScreenAnimator;

    private void Awake()
    {
        startScreenAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Hide()
    {
        startScreenAnimator.SetTrigger("HideStartScreen");
    }
}