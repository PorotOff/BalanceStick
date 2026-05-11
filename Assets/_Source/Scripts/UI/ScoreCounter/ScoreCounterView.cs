using TMPro;
using UnityEngine;

public class ScoreCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounterText;
    [SerializeField] private Animator _animator;

    public void DisplayScore(int score)
    {
        _scoreCounterText.text = $"{score}";
    }

    public void SetMultiplicationAnimation()
    {
        _animator.SetBool("Multiplication", true);
    }

    public void DisableMultiplicationAnimation()
    {
        _animator.SetBool("Multiplication", false);
    }
}