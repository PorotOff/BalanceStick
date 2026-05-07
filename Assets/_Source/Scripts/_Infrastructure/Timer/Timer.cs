using System;

public class Timer
{
    private float _tickPerMilliseconds;
    private float _durationMilliseconds;
    
    private float _elapsedTimeForTick = 0;
    private float _elapsedTime = 0;
    private bool _isWorking = false;

    public event Action Ticked;
    public event Action TimeElapsed;

    public float RemainedTime => _durationMilliseconds - _elapsedTime;

    /// <summary>
    /// 1 сек. = 1000 миллисек.
    /// </summary>
    /// <param name="tickPerMilliseconds">Раз во сколько миллисекунд будет вызываться Tick</param>
    /// <param name="durationMilliseconds">Сколько миллисекунд будет идти таймер</param>
    public Timer(float tickPerMilliseconds, float durationMilliseconds)
    {
        _tickPerMilliseconds = tickPerMilliseconds;
        _durationMilliseconds = durationMilliseconds;
    }

    public void Work(float deltaTime)
    {
        if (_isWorking == false)
            return;

        _elapsedTime += deltaTime;
        _elapsedTimeForTick += deltaTime;

        if (_elapsedTimeForTick >= _tickPerMilliseconds)
        {
            Ticked?.Invoke();
            _elapsedTimeForTick = 0;
        }

        if (_elapsedTime >= _durationMilliseconds)
        {
            TimeElapsed?.Invoke();
        }
    }

    public void Start()
    {
        Stop();
        _isWorking = true;
    }

    public void Stop()
    {
        _isWorking = false;
        _elapsedTime = 0;
        _elapsedTimeForTick = 0;
    }

    public void Pause()
    {
        _isWorking = false;
    }

    public void Continue()
    {
        _isWorking = true;
    }

    public void Skip()
    {
        Stop();
        TimeElapsed?.Invoke();
    }
}