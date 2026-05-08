using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Conditions")]
    [SerializeField] private Holdling _holdling;

    [Header("Actions")]
    [SerializeField] private LosePage _losePage;

    private void OnEnable()
    {
        _holdling.Demolished += OnHoldlingDemolished;
    }

    private void OnDisable()
    {
        _holdling.Demolished += OnHoldlingDemolished;
    }

    private void OnHoldlingDemolished()
    {
        _losePage.Open();
    }
}
