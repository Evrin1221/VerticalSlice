using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public float sanity = 100f;
    [SerializeField] public float awakeness = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CapSanity();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyHit += HandleEnemyHit;
        PlayerMovement.OnHitHealthPotion += HandleGetHealthPotion;
        Attack.OnPlayerHitEnemy += HandleAwakeness;

    }

    private void OnDisable()
    {
        Enemy.OnEnemyHit -= HandleEnemyHit;
        PlayerMovement.OnHitHealthPotion -= HandleGetHealthPotion;
        Attack.OnPlayerHitEnemy -= HandleAwakeness;
    }

    private void HandleEnemyHit(Enemy enemy)
    {
        sanity -= enemy.GetDamageDealt();
    }

    private void HandleGetHealthPotion()
    {
        sanity += Locator.Instance._player.GetHealthPotionBonus(); 
    }

    private void HandleAwakeness(Attack attack)
    {
        awakeness += attack.GetDamage();
    }
    public float GetSanity()
    { 
        return sanity;
    }

    private void CapSanity()
    {
        if (sanity > 100)
        {
            sanity = 100;
        }
    }

    public float GetAwakeness()
    {
        return awakeness;
    }
}
