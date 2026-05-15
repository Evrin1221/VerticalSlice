using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update

  

    void Start()
    {

    
    }

 

    
   public void UpdateGrenadeCount(int num)
    {
        Locator.Instance._inventory.UpdateGrenadeCount(num);
    }



}
