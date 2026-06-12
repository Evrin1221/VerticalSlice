using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Attack
{
    [SerializeField] private float _lifeTime = 0.5f;
    protected override void OnEnable()
    {
        base.OnEnable();
        
        Invoke(nameof(DisableSlash), _lifeTime);
    }

    private void DisableSlash()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

  

}
