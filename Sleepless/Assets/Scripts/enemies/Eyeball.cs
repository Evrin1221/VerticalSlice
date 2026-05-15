using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : Enemy
{
  
    protected override void Attack()
    {
        _animator.Play("attack");

    }

}
