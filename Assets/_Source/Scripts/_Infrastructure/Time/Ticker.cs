using System;

public class Ticker
{
    private float _tickPerMilliseconds;
    
    private float _elapsedTimeForTick = 0;
    private bool _isWorking = false;

    public event Action Ticked;

    /// <summary>
    /// 1 сек. = 1000 миллисек.
    /// </summary>
    /// <param name="tickPerMilliseconds">Раз во сколько миллисекунд будет вызываться Tick</param>
    public Ticker(float tickPerMilliseconds)
    {
        _tickPerMilliseconds = tickPerMilliseconds;
    }

    public virtual void Work(float deltaTime)
    {
        if (_isWorking == false)
            return;

        _elapsedTimeForTick += deltaTime;

        if (_elapsedTimeForTick >= _tickPerMilliseconds)
        {
            Ticked?.Invoke();
            _elapsedTimeForTick = 0;
        }
    }

    public void Start()
    {
        Stop();
        _isWorking = true;
    }

    public virtual void Stop()
    {
        _isWorking = false;
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
}