using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTimer = 10.0f;
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;
    [SerializeField] private EnemyWaves _enemyWaves;

    private float _elapsedTime = 0.0f;
    private int _cycleCount = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnTimer)
        {
            _elapsedTime = 0.0f;
            for (int i = 0; i < _enemyWaves.enemies[_cycleCount].enemyCount; i++)
            {
                SpawnEnemy();
            }
            ++_cycleCount;
            if (_cycleCount >= _enemyWaves.enemies.Count)
            {
                _cycleCount = _enemyWaves.enemies.Count - 1;
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 pos = GameConstants.player.transform.position;
        pos.y = 0.0f;
        Vector2 point = Random.insideUnitCircle * Random.Range(_minRadius, _maxRadius);
        pos.x += point.x;
        pos.z += point.y;

        Instantiate(_enemyWaves.enemies[_cycleCount].enemy, pos, Quaternion.identity, transform);
        //newEnemy.transform.position = pos;
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
