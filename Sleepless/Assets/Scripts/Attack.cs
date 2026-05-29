using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected float _damage;


    public static event Action<Attack> OnPlayerHitEnemy;

    
       
   

    protected virtual void Start()
    {

    }

    public float GetDamage()
    {
        return _damage;
    }

    protected virtual void OnEnable()
    {

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            OnPlayerHitEnemy?.Invoke(this);
        }
    }
}

