using System;

public class Timer : Ticker
{
    private float _durationMilliseconds;
    
    private float _elapsedTime = 0;
    
    public event Action TimeElapsed;

    public float RemainedTime => _durationMilliseconds - _elapsedTime;

    /// <summary>
    /// 1 сек. = 1000 миллисек.
    /// </summary>
    /// <param name="tickPerMilliseconds">Раз во сколько миллисекунд будет вызываться Tick</param>
    /// <param name="durationMilliseconds">Сколько миллисекунд будет идти таймер</param>
    public Timer(float tickPerMilliseconds, float durationMilliseconds) : base (tickPerMilliseconds)
    {
        _durationMilliseconds = durationMilliseconds;
    }

    public override void Work(float deltaTime)
    {
        base.Work(deltaTime);

        _elapsedTime += deltaTime;

        if (_elapsedTime >= _durationMilliseconds)
        {
            TimeElapsed?.Invoke();
        }
    }

    public override void Stop()
    {
        base.Stop();
        _elapsedTime = 0;
    }

    public void Skip()
    {
        Stop();
        TimeElapsed?.Invoke();
    }
}