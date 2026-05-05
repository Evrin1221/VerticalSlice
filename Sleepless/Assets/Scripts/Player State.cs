using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public float sanity = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Enemy.OnEnemyHit += HandleEnemyHit;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyHit -= HandleEnemyHit;
    }

    private void HandleEnemyHit(Enemy enemy)
    {
        sanity -= enemy.GetDamageDealt();
    }

    public float GetSanity()
    { 
        return sanity;
    }
}
