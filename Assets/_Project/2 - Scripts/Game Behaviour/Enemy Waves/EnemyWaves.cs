using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom", fileName = "New enemy wave")]
public class EnemyWaves : ScriptableObject
{
    public List<EnemyWave> enemies;
}

[System.Serializable]
public class EnemyWave
{
    public int enemyCount;
    public GameObject enemy;
}
