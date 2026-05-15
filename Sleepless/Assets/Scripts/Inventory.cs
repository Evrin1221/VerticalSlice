using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    //use this when i have multiple collectables
    /*
    
    [SerializeField] private CollectableData[] _collectableTypes;
    [System.Serializable]
    public class CollectableData
    {
        public GameObject collectablePrefab;
        public int count;
    }
    */

    private int _grenadeCount = 0;

    public void UpdateGrenadeCount(int amount)
    {
        _grenadeCount += amount;
        Debug.Log("Grenades: " + _grenadeCount);
    }

    public int GetGrenadeCount()
    {
        return _grenadeCount;
    }
}
