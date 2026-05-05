using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _sanity;
    [SerializeField] public float sanity =100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _sanity.text = "Sanity:" + sanity;
        
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
}
