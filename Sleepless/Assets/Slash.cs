using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Attack
{
    [SerializeField] private float _lifeTime = 0.5f;
    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, _lifeTime);
    }

 
}
