using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] _enemies;
    [SerializeField] GameObject[] _spawnPoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for(int i=0; i<_enemies.Length; i++)
        {
            _enemies[i].
        }
    }

    private void SpawnCooldownTimer(float _spawnCooldown)
    {
        
    }

    
}
