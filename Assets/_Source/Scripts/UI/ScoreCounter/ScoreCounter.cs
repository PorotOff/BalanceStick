using UnityEngine;

[RequireComponent(typeof(ScoreCounterView))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Holdling _holdling;
    [SerializeField] private float _multiplicationAngle = 90f;
    [SerializeField] private float _countPerMillisecondCommon = 500f;
    [SerializeField] private float _countPerMillisecondAtVertical = 200f;
    [SerializeField] private int _addableScore = 1;

    private Ticker _ticker;
    private ScoreCounterView _scoreCounterView;

    private float _countPerMillisecon;

    public static int Score { get; private set; }

    private void Update()
    {
        _ticker.Work(Time.deltaTime);
    }

    public void Initialize()
    {
        _countPerMillisecon = _countPerMillisecondCommon;
        _ticker = new Ticker(_countPerMillisecon);    

        Subscribe();

        _ticker.Start();
    }

    private void Subscribe()
    {
        _ticker.Ticked += OnTicked;
    }

    private void Unsubscribe()
    {
        _ticker.Ticked -= OnTicked;
    }

    private void OnTicked()
    {    
        Score += _addableScore;
        float holdlingZAngle = _holdling.transform.eulerAngles.z;

        if (holdlingZAngle >= 360 - _multiplicationAngle / 2 || holdlingZAngle <= _multiplicationAngle / 2)
        {
            _countPerMillisecon = _countPerMillisecondAtVertical;
            _ticker = new Ticker(_countPerMillisecon);

            // _scoreCounterView.SetMultiplicationAnimation();
        }

        _scoreCounterView.DisplayScore(Score);
        // _scoreCounterView.DisableMultiplicationAnimation();
    }
}