using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [Header("Conditions")]
    [SerializeField] private Dragger _dragger;

    [Header("Actions")]
    [SerializeField] private GameplayUIPage _gameplayUIPage;

    private void OnEnable()
    {
        _dragger.PickedUp += OnPickedUp;
    }

    private void OnDisable()
    {
        _dragger.PickedUp -= OnPickedUp;
    }

    private void OnPickedUp()
    {
        _gameplayUIPage.Open();
    }
}