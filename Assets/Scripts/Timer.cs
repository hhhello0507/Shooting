using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Timer
{
    private float _currentTime;
    private readonly float _minTime;
    private readonly float _maxTime;
    private readonly Action _callback;
    private float _createTime;

    public Timer(float initialTime, float delay, Action callback)
    {
        _currentTime = -initialTime;
        _minTime = delay;
        _maxTime = delay;
        _callback = callback;
    }

    public Timer(float initialTime, float minTime, float maxTime, Action callback)
    {
        _currentTime = -initialTime;
        _minTime = minTime;
        _maxTime = maxTime;
        _callback = callback;
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _createTime)
        {
            _callback.Invoke();
            _currentTime = 0;
            _createTime = Random.Range(_minTime, _maxTime);
        }
    }
}