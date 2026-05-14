using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private EnemySpawnData[] _enemyTypes;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject[] _retreatPoints;

    private float[] _spawnTimers;


    [System.Serializable]

    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public float spawnCooldown;
    }
    void Start()
    {
        _spawnTimers = new float[_enemyTypes.Length];

        for( int i=0; i< _enemyTypes.Length; i++ )
        {
            _spawnTimers[i] = _enemyTypes[i].spawnCooldown;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for(int i =0; i<_enemyTypes.Length;i++)
        {
            _spawnTimers[i] -=Time.deltaTime;

            if(_spawnTimers[i] < 0)
            {
                
                SpawnEnemy(i);
                _spawnTimers[i] = _enemyTypes[i].spawnCooldown;
            }
        }
        
    }

    private void SpawnEnemy(int index)
    {
        Instantiate(_enemyTypes[index].enemyPrefab,PickSpawnPoint(),Quaternion.identity);
    }

    private Vector3 PickSpawnPoint()
    {
        int index = UnityEngine.Random.Range(0,_spawnPoints.Length);

        Vector3 _spawnPoint = _spawnPoints[index].transform.position;

        return _spawnPoint;

    }

    public Vector3 getRetreatPoint()
    {
        int index = UnityEngine.Random.Range(0,_retreatPoints.Length);

        Vector3 _retreatPoint = _retreatPoints[index].transform.position;

        return _retreatPoint; 
    }

    
}
