using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTimer = 10.0f;

    private float _elapsedTime = 0.0f;
    private int _cycleCount = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnTimer)
        {
            _elapsedTime = 0.0f;
            ++_cycleCount;
        }
    }

    public float GetRemainingTime()
    {
        return (_spawnTimer - _elapsedTime);
    }

    public float GetMaxTime()
    {
        return (_spawnTimer);
    }
}
