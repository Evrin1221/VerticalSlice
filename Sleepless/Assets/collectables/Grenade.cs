using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update

    private int _grenadeCount = 0;

    void Start()
    {

    
    }

 
    public int GetGrenadeCount()
    {
       return _grenadeCount;
    }

    
   public void UpdateGrenadeCount(int num)
    {
        _grenadeCount += num;
    }



}
