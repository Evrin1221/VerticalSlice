using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected float _damage;

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
}

